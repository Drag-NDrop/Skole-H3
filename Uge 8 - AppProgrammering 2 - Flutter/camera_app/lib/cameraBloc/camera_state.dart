// Statehandler logic, Bloc pattern
// This class encapsulates the logic we want for the state, the bloc is brokering.
// We can fire the methods here, in the emitters in the bloc, to get the desired operations performed, based on current state of the app.

import 'dart:convert'; // Allow Base64 encoding and decoding
import 'dart:math'; // Allow mathematic calculations.. Most probably not useful to the project
import 'dart:typed_data'; // Allow use of Uint8List's
import 'package:camera_app/repository/local_image_repository.dart';
import 'package:flutter/material.dart'; // Allow use of UI elements
import 'package:universal_io/io.dart'; // Allow use of httpclient
import '../models/imageDef.dart'; // Allow use of the imageDef class
import '../repository/image_repository.dart';
import 'package:camera_app/models/settings.dart';

class CameraState {
  // Private constructor
  CameraState._privateConstructor();

  // Static member to cache the singleton instance
  static final CameraState _instance = CameraState._privateConstructor();

  // Factory method to return the same instance every time its called
  factory CameraState() {
    return _instance;
  }

  ImageRepository _repository = LocalImageRepository();
  ImageRepository get repository => _repository;
  set repository(ImageRepository value) {
    _repository = value;
  }

  Settings settings = Settings();
  final httpClient = HttpClient();
  late List<ImageDef> imageDefImages = List.empty(growable: true);
  late List<Widget> imageDefWidgets = List.empty(growable: true);

  // Repository interface methods:
  // repository.loadImages
  // repository.saveImage

  Future<List<Widget>> generateImageWidgetsFromRepository() async {
    // this.imageDefImages = await _repository.loadImages(); // populate the class's imageDefImages
    // Then populate the class's imageDefWidgets. Just in case anyone want it, return it as well.
    // if the caller doesn't want it, the caller is free to discard it.
    imageDefWidgets = List.empty(
        growable: true); // Reset the imageDefWidgets, so we don't get doubles.
    for (ImageDef image in imageDefImages) {
      Widget imageWidget = Container(
        width: 25, // Set the width of each image
        child: Image.memory(image.imageData, fit: BoxFit.cover),
      );
      imageDefWidgets.add(imageWidget);
    }
    print("Done processing imageDefImages. Returning results...");
    return imageDefWidgets;
  }

  Future<List<Widget>> generateSingleImageWidget(ImageDef image) async {
    // this.imageDefImages = await _repository.loadImages(); // populate the class's imageDefImages
    // Then populate the class's imageDefWidgets. Just in case anyone want it, return it as well.
    // if the caller doesn't want it, the caller is free to discard it.
    Widget imageWidget = Container(
      width: 25, // Set the width of each image
      child: Image.memory(image.imageData, fit: BoxFit.cover),
    );
    imageDefWidgets.add(imageWidget);

    print("Done processing imageDefImages. Returning results...");
    return imageDefWidgets;
  }
}
