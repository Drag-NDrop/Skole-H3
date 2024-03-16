import '../models/imageDef.dart';

abstract class ImageRepository {
  Future<List<ImageDef>> loadImages();
  Future<bool> saveImage(ImageDef image);
}
