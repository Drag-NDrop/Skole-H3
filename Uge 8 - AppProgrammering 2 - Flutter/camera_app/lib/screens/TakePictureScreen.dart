import 'dart:convert';
import 'dart:typed_data';

import 'package:camera/camera.dart';
import 'package:camera_app/cameraBloc/camera_bloc.dart';
import 'package:camera_app/models/imageDef.dart';
import 'package:camera_app/repository/image_repository.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:go_router/go_router.dart';
import 'package:universal_io/io.dart';

class TakePictureScreen extends StatefulWidget {
  //final ImageRepository imageRepository;
  const TakePictureScreen({super.key});

  @override
  State<TakePictureScreen> createState() => _TakePictureScreenState();
}

class _TakePictureScreenState extends State<TakePictureScreen> {
  Uint8List imageData = Uint8List(0);
  String imageString = "";
  List<String> images = [];
  List<CameraDescription>? _cameras; // Make _cameras nullable
  CameraController? controller;

  Future<void> initializeCameras() async {
    _cameras = await availableCameras();
  }

  @override
  void initState() {
    super.initState();
    initializeCameras().then((_) {
      if (_cameras != null && _cameras!.isNotEmpty) {
        // Check if _cameras is not null before using it
        controller = CameraController(_cameras![0], ResolutionPreset.max);
        controller?.initialize().then((_) {
          // Use null-aware access operator
          if (!mounted) {
            return;
          }
          setState(() {});
        });
      }
    });
  }

  @override
  void dispose() {
    controller?.dispose(); // Use null-aware access operator
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    if (controller == null || !controller!.value.isInitialized) {
      // Use null-aware access operator
      return Container();
    }
    return MaterialApp(
      home: Column(
        children: [
          CameraPreview(controller!),
          Padding(
            padding: const EdgeInsets.only(top: 10.0),
            child: Row(
              children: [
                FloatingActionButton(
                    heroTag: "BackButton",
                    child: const Icon(Icons.arrow_back),
                    onPressed: () {
                      Navigator.pop(context);
                    }),
                const SizedBox(width: 10),
                FloatingActionButton(
                    heroTag: "GalleryButton",
                    child: const Icon(Icons.image_search),
                    onPressed: () {
                      Navigator.pop(context);
                      context.go('/viewPictureScreen');
                    }),
              ],
            ),
          ),
          FloatingActionButton(
            heroTag: "TakePictureButton",
            shape: CircleBorder(),
            onPressed: () async {
              XFile file = await (controller?.takePicture() ??
                  Future.value(XFile(
                      ''))); // If null, return something empty Xfile! Else, take the picture
              print('Picture saved at ${file.path}');

              // Read the file
              imageData = await File(file.path).readAsBytes();

              // Convert to base64
              imageString = base64Encode(imageData);
              print('Camera-TakePicture:: Image was Base64 encoded');

              // Create an ImageDef
              ImageDef image = ImageDef(
                  base64image: imageString, offset: const Offset(0.1, 0.1));

              // Save the image using the repository
              bool success = (await context
                  .read<CameraBloc>()
                  .state
                  .repository
                  .saveImage(image));

              if (await success) {
                // Update the UI
                print("Successfully saved the picture to the repository...");

                setState(() {
                  images.add(imageString);
                });
              } else {
                print(
                    "Something went wrong while saving the picture to the repository");
              }
            },
            child: (const Icon(Icons.camera_alt)),
          ),
          if (images.isNotEmpty)
            Padding(
              padding:
                  const EdgeInsets.only(top: 3.0), // Adjust the value as needed
              child: Container(
                height: 30, // Set the height of the ListView
                child: ListView.builder(
                  scrollDirection: Axis.horizontal,
                  itemCount: images.length,
                  itemBuilder: (context, index) {
                    return Container(
                      width: 60, // Set the width of each image
                      child: Image.memory(base64Decode(images[index]),
                          fit: BoxFit.cover),
                    );
                  },
                ),
              ),
            ),
        ],
      ),
    );
  }
}
