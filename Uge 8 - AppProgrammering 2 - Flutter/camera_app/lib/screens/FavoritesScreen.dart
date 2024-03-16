import 'dart:convert';
import 'dart:typed_data';

import 'package:flutter/material.dart';
import 'package:localstorage/localstorage.dart';

class FavoritesScreen extends StatefulWidget {
  const FavoritesScreen({super.key});

  @override
  State<FavoritesScreen> createState() => _FavoritesScreenState();
}

class DroppedItem {
  final Widget widget;
  final Offset position;
  final Uint8List imageData;
  final String base64Image;
  DroppedItem(
      {required this.widget,
      required this.position,
      required this.imageData,
      required this.base64Image});
}

class _FavoritesScreenState extends State<FavoritesScreen> {
  final LocalStorage storage = LocalStorage('camera_app_images.json');
  List<String> images = [];

  @override
  void initState() {
    super.initState();
    loadImages();
  }

  void loadImages() async {
    await storage.ready;
    var base64ImagesFromStorage = storage.getItem('images');
    images = base64ImagesFromStorage != null
        ? List<String>.from(base64ImagesFromStorage)
        : [];
    setState(() {});
  }

  List<DroppedItem> droppedItems = [];
  @override
  Widget build(BuildContext context) {
    return Column(
      children: <Widget>[
        Container(
          height: MediaQuery.of(context).size.height * 0.7,
          width: MediaQuery.of(context).size.width,
          decoration: BoxDecoration(
            image: droppedItems.isNotEmpty
                ? DecorationImage(
                    image: MemoryImage(droppedItems.last.imageData),
                    fit: BoxFit.cover,
                  )
                : null,
          ),
          child: Stack(
            children: droppedItems.map((droppedItem) {
              return Positioned(
                left: droppedItem.position.dx,
                top: droppedItem.position.dy,
                child: droppedItem.widget,
              );
            }).toList(),
          ),
        ),
        Container(
          height: MediaQuery.of(context).size.height * 0.3,
          color: const Color.fromARGB(255, 59, 50, 112),
          child: ListView.builder(
            scrollDirection: Axis.horizontal,
            itemCount: images.length,
            itemBuilder: (context, index) {
              Uint8List imageData = base64Decode(images[index]);

              Widget imageWidget = SizedBox(
                width: 60,
                child: Image.memory(
                  imageData,
                  height: MediaQuery.of(context).size.height * 0.3,
                ),
              );
              return LongPressDraggable<Widget>(
                data: imageWidget,
                feedback: imageWidget,
                child: imageWidget,
                onDragEnd: (details) {
                  setState(() {
                    droppedItems.add(DroppedItem(
                        widget: imageWidget,
                        position: details.offset,
                        imageData: imageData,
                        base64Image: images[index]));
                  });
                },
              );
            },
          ),
        )
      ],
    );
  }
}
