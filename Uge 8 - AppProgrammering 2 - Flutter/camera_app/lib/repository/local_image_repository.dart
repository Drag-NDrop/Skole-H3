import 'package:flutter/material.dart';

import 'image_repository.dart'; // Allow use of the ImageRepository abstract class(Interface)

import '../models/imageDef.dart'; // Allow use of the imageDef class

import 'package:localstorage/localstorage.dart'; // Allow use of LocalStorage

class LocalImageRepository implements ImageRepository {
  final LocalStorage storage = LocalStorage('camera_app_images.json');

  @override
  Future<List<ImageDef>> loadImages() async {
    // Prepare the return result of the method
    List<ImageDef> imgList = List.empty(growable: true);

    // Load images from local storage
    await storage.ready;
    var base64ImagesFromStorage = storage.getItem(
        'images'); // images are stored as a single JSON key named "images". Each image is then a base64 string.
    // To avoid spending time expanding just to make a full repository alternative, i'll just null out the offsets imageDefs requires.

    List<String> base64Images = base64ImagesFromStorage != null
        ? List<String>.from(base64ImagesFromStorage)
        : [];

    for (String image in base64Images) {
      imgList.add(
          // For each saved image, create an ImageDef, with an unused offset.
          ImageDef(base64image: image, offset: Offset(0.0, 0.0)));
    }
    print("LocalStorage:: ${imgList.length} pictures was loaded...");
    return imgList;
  }

  @override
  Future<bool> saveImage(ImageDef image) async {
    // Get the list of images from localstorage, or initialize a new list if it's null
    var storedImages = storage.getItem('images');
    List<String> images = storedImages != null
        ? (storedImages as List<dynamic>).cast<String>()
        : [];

    // Add the new image to the list
    images.add(image.base64image);
    try {
      // Save the list back to localstorage
      await storage.ready;
      storage.setItem('images', images);
      print("LocalStorage:: Image was saved successfully");
      return true;
    } catch (e) {
      print("An error occured while writing the new image list to storage");
      print(e.toString());
      return false;
    }
  }
}
