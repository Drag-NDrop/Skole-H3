import 'package:flutter_bloc/flutter_bloc.dart';

import 'package:provider_pattern/counter_change/event/counter_change_event.dart';
import 'package:provider_pattern/counter_change/state/counter_change_state.dart';

// Custom statehandler logic. Decides how to act upon recieved events. And what to pass back. Does so by analyzing the recieved event, and fire the desired data-fetcher inside the emitter.
// The emitter then transmits back the desired value.
class CounterChangeBloc extends Bloc<CounterChangeEvent, CounterChangeState>{

  CounterChangeBloc() : super(CounterChangeState()..init()){
    on<CounterIncrementEvent>((event, emit) => emit(state.increment(state)));
    on<CounterDecrementEvent>((event, emit) => emit(state.decrement(state)));
  }

}