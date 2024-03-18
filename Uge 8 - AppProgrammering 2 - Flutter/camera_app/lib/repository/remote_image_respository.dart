import 'dart:convert'; // Allow for encoding and decoding Base64
import 'dart:isolate';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';

import 'image_repository.dart'; // Allow use of the ImageRepository abstract class(Interface)
import '../models/imageDef.dart'; // Allow use of the imageDef class
import 'package:universal_io/io.dart'; // Allow use of the HttpClientResponse

class RemoteImageRepository implements ImageRepository {
  HttpClient httpClient = HttpClient();

  @override
  Future<List<ImageDef>> loadImages() async {
    print("RemoteRepository:: loadImages() Was called!");
    // Use 'dart:io' HttpClient API.
    final request =
        await httpClient.getUrl(Uri.parse('http://100.77.74.4:5203/api/Image'));
    request.headers.set('content-type', 'application/json');
    final response = await request.close();

    // Parse response and fill the CameraState list with images
    final responseBody = await response.transform(utf8.decoder).join();

    // Check the response status code
    // This runs in an isolate, and will just print the corresponding status for the status code.
    // Under normal circumstances, this is supposed to be an optimizing upgrade.
    // But in this case, because the unit of work is so small, it's actually a performance degradation.
    // Because spinning up an isolate, takes time. More time than it would take to calculate this in the main thread.
    handleResponse(response.statusCode);

    // Decode the String into a JSON object
    // We use compute, as there's no need to block the main thread while doing this.
    final jsonBody = await compute(jsonDecode, responseBody);

// Organize the json data recieved, to objects
    List<ImageDef> images = [];
    for (var item in jsonBody) {
      ImageDef image = ImageDef(
        offset: Offset(item['posX'], item['posY']),
        base64image: item['imageBase64'],
      );
      images.add(image);
    }
    print("Total images recieved from server: ${images.length}");
    return images;
  }

  @override
  Future<bool> saveImage(ImageDef image) async {
    final request = await httpClient
        .postUrl(Uri.parse('http://100.77.74.4:5203/api/Image'));
    request.headers.set('content-type', 'application/json');

    // Convert the ImageDef object to a JSON object
    final jsonBody = jsonEncode({
      //'id': image.id, // Assuming ImageDef has an id property
      'imageBase64': image.base64image,
      'posX': image.offset?.dx,
      'posY': image.offset?.dy,
    });

    // Write the JSON object to the request body
    request.write(jsonBody);

    // Send the request and return the response
    final response = await request.close();
    handleResponse(response.statusCode);
    print("status code: ${response.statusCode.toString()}");
    if (response.statusCode == 200 | 201) {
      return true;
    } else {
      return false;
    }
  }
}

// This function will run in a separate isolate.
void checkHttpStatusCode(Map<String, dynamic> isolateData) {
  final sendPort = isolateData['sendPort'];
  final statusCode = isolateData['statusCode'];

  String statusMessage;
  if (statusCode == 200) {
    statusMessage = 'Response status code: 200 - OK';
  } else if (statusCode == 201) {
    statusMessage = 'Response status code: 201 - Created';
  } else if (statusCode == 204) {
    statusMessage = 'Response status code: 204 - No Content';
  } else if (statusCode == 400) {
    statusMessage = 'Response status code: 400 - Bad Request';
  } else if (statusCode == 401) {
    statusMessage = 'Response status code: 401 - Unauthorized';
  } else if (statusCode == 403) {
    statusMessage = 'Response status code: 403 - Forbidden';
  } else if (statusCode == 404) {
    statusMessage = 'Response status code: 404 - Not Found';
  } else if (statusCode == 500) {
    statusMessage = 'Response status code: 500 - Internal Server Error';
  } else if (statusCode == 502) {
    statusMessage = 'Response status code: 502 - Bad Gateway';
  } else if (statusCode == 503) {
    statusMessage = 'Response status code: 503 - Service Unavailable';
  } else {
    statusMessage = 'Response status code: ${statusCode}';
  }

  // Send the status message back to the main isolate.
  sendPort.send(statusMessage);
}

Future<void> handleResponse(int statusCode) async {
  // Create a ReceivePort to receive messages from the isolate.
  final receivePort = ReceivePort();

  // Start the isolate.
  await Isolate.spawn(
    checkHttpStatusCode,
    {
      'sendPort': receivePort.sendPort,
      'statusCode': statusCode,
    },
  );

  // Receive the status message from the isolate.
  final statusMessage = await receivePort.first;

  print(statusMessage);
}
