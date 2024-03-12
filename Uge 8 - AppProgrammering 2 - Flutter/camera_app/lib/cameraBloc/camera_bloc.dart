import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:camera_app/cameraBloc/camera_event.dart';
import 'package:camera_app/cameraBloc/camera_state.dart';

//import 'package:camera_app/cameraBloc/cameraEvent';

// Custom statehandler logic. Decides how to act upon recieved events. And what to pass back. Does so by analyzing the recieved event, and fire the desired data-fetcher inside the emitter.
// The emitter then transmits back the desired value.
class CameraBloc extends Bloc<CameraEvent, CameraState> {
  CameraBloc() : super(CameraState()..init()) {
    on<NewPictureEvent>((event, emit) => emit(state.newRandom(state)));
    on<SavePictureEvent>((event, emit) => emit(state.increment(state)));
    on<LoadPicturesEvent>((event, emit) => emit(state.decrement(state)));
    on<ViewPictureEvent>((event, emit) => emit(state.decrement(state)));
  }
}
