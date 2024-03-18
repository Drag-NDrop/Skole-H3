import 'dart:typed_data';
import 'package:flutter/material.dart';

class FullScreenImageScreen extends StatelessWidget {
  final Uint8List image;

  FullScreenImageScreen({required this.image});

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        Navigator.pop(context);
      },
      child: Center(
        child: Image.memory(image),
      ),
    );
  }
}
