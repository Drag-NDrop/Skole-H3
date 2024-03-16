import 'dart:convert'; // Allow Base64 Decoding
import 'dart:typed_data'; // Allow use of Uint8List's
import 'package:flutter/material.dart'; // Allow use of Offset

class ImageDef {
  Offset offset;
  String base64image;
  late Uint8List imageData;
  ImageDef({
    required this.offset,
    required this.base64image,
  }) {
    print("ImageDef:: Attempting to decode base64: ${base64image}");
    try {
      this.imageData = base64Decode(base64image);
      print("Base64 was decoded successfully...");
    } catch (e) {
      print('Error decoding Base64 string: $base64image');
      print('Exception: $e');
    }
  }
}
