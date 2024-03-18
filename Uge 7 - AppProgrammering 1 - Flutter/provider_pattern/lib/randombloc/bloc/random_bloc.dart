import 'package:flutter_bloc/flutter_bloc.dart';

import 'package:provider_pattern/randombloc/event/random_number_event.dart';
import 'package:provider_pattern/randombloc/state/random_number_state.dart';

// Custom statehandler logic. Decides how to act upon recieved events. And what to pass back. Does so by analyzing the recieved event, and fire the desired data-fetcher inside the emitter.
// The emitter then transmits back the desired value.
class RandomNumberBloc extends Bloc<RandomNumberEvent, RandomNumberState>{

  RandomNumberBloc() : super(RandomNumberState()..init()){
    on<NewRandomEvent>((event, emit) => emit(state.newRandom(state)));
    on<RandomIncrementEvent>((event, emit) => emit(state.increment(state)));
    on<RandomDecrementEvent>((event, emit) => emit(state.decrement(state)));
  }

}