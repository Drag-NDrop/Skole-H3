import 'package:camera_app/repository/image_repository.dart';
import 'package:camera_app/repository/local_image_repository.dart';
import 'package:camera_app/repository/remote_image_respository.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:camera_app/cameraBloc/camera_event.dart';
import 'package:camera_app/cameraBloc/camera_state.dart';

import '../models/imageDef.dart';

class CameraBloc extends Bloc<CameraEvent, CameraState> {
  CameraBloc() : super(CameraState()) {
    on<LoadPicturesEvent>((event, emit) async {
      print("Loading pictures...");

      // Call the loadImages method from your repository
      state.imageDefImages = await state.repository.loadImages();

      // Emit the new state
      emit(state);
    });

    on<SavePictureEvent>((event, emit) async {
      print("Saving picture...");

      // Call the saveImage method from your repository
      bool success = await state.repository.saveImage(event.image);

      // Check if the image was saved successfully
      if (success) {
        // If the image was saved successfully, add it to the state
        state.imageDefImages.add(event.image);
        await state.generateSingleImageWidget(event.image);
      }

      // Emit the new state
      emit(state);
    });

    on<ReloadPicturesEvent>((event, emit) async {
      print("Loading pictures...");
      switch (event.desiredRepository) {
        case 'local':
          {
            state.repository = LocalImageRepository();
            print("Adjusted the repository to use: Local");
          }
          break;
        case 'remote':
          {
            state.repository = RemoteImageRepository();
            print("Adjusted the repository to use: Remote");
          }
        default:
          break;
      }
      // Call the loadImages method from the adjusted repository
      state.imageDefImages = await state.repository.loadImages();

      // Emit the new state
      emit(state);
    });
  }
}
