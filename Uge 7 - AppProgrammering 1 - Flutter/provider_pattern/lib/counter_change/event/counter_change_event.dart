
// Custom statehandler logic
// Offers events, which are used purely to discern a type from. The recieving of a type, can then be acted upon, by the bloc.
abstract class CounterChangeEvent{}
class CounterIncrementEvent extends CounterChangeEvent{}
class CounterDecrementEvent extends CounterChangeEvent{}