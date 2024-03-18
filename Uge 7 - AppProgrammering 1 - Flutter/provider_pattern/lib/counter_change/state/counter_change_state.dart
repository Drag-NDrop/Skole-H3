// Custom statehandler logic
// This class encapsulates the logic we want for the state, the bloc is brokering.
// We can fire the methods here, in the emitters in the bloc, to get the desired operations performed, based on current state of the app.

class CounterChangeState {
 late int _currentNumber = 0;
 int get currentValue => _currentNumber;


  CounterChangeState init() {
    return CounterChangeState().._currentNumber = 0;
  }

  CounterChangeState increment(CounterChangeState currentState){
    print(currentState._currentNumber);
    return CounterChangeState()
    .._currentNumber = currentState.currentValue
    .._currentNumber += 1;
  }


  CounterChangeState decrement(CounterChangeState currentState){
    print(currentState._currentNumber);
    return CounterChangeState()
    .._currentNumber = currentState.currentValue
    .._currentNumber = _currentNumber == 0 ? 0 : _currentNumber -= 1;
  }
}