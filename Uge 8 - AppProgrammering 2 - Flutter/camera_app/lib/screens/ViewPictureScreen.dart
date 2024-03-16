import 'package:camera_app/cameraBloc/camera_state.dart';
import 'package:camera_app/screens/FullScreenImageScreen.dart';
import 'package:flutter/material.dart';

class ViewPictureScreen extends StatefulWidget {
  final CameraState cameraState = CameraState();

  ViewPictureScreen({Key? key}) : super(key: key);

  @override
  State<ViewPictureScreen> createState() => _ViewPictureScreenState();
}

class _ViewPictureScreenState extends State<ViewPictureScreen> {
  List<Widget> images = [];

  @override
  void initState() {
    super.initState();
    loadImages();
  }

  void loadImages() async {
    images = await widget.cameraState.generateImageWidgetsFromRepository();
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('View Pictures'),
      ),
      body: GridView.builder(
        gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
            crossAxisCount: 3, // number of items per row
            mainAxisSpacing: 20,
            crossAxisSpacing: 10),
        itemCount: images.length,
        itemBuilder: (context, index) {
          return InkWell(
            onTap: () {
              Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => FullScreenImageScreen(
                    image: widget.cameraState.imageDefImages[index].imageData,
                  ),
                ),
              );
            },
            child: images[index],
          );
        },
      ),
    );
  }
}
