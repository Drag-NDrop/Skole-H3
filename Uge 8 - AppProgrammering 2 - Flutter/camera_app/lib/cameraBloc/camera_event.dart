import 'package:camera_app/models/imageDef.dart';

abstract class CameraEvent {}

class SavePictureEvent extends CameraEvent {
  final ImageDef image;
  SavePictureEvent({required this.image});
}

class LoadPicturesEvent extends CameraEvent {}

class ReloadPicturesEvent extends CameraEvent {
  final String desiredRepository;
  ReloadPicturesEvent({required this.desiredRepository});
}
