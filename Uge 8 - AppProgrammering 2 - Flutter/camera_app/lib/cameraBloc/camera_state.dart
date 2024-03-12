// Statehandler logic, Bloc pattern
// This class encapsulates the logic we want for the state, the bloc is brokering.
// We can fire the methods here, in the emitters in the bloc, to get the desired operations performed, based on current state of the app.
import 'dart:math';

class CameraState {
  late int _currentNumber = 0;
  int get currentValue => _currentNumber;

  int increaseRandom() {
    int test = Random().nextInt(100);
    if (_currentNumber + test > 100) {
      return 100;
    } else {
      return _currentNumber + test;
    }
  }

  int decreaseRandom() {
    int test = Random().nextInt(_currentNumber);
    if (_currentNumber - test >= 0) {
      return _currentNumber - test;
    } else {
      return 0;
    }
  }

  CameraState init() {
    return CameraState().._currentNumber = 0;
  }

  CameraState increment(CameraState currentState) {
    print(currentState._currentNumber);
    return CameraState()
      .._currentNumber = currentState.currentValue
      .._currentNumber = increaseRandom();
  }

  CameraState decrement(CameraState currentState) {
    print(currentState._currentNumber);
    return CameraState()
      .._currentNumber = currentState.currentValue
      .._currentNumber = decreaseRandom();
  }

  CameraState newRandom(CameraState currentState) {
    return CameraState().._currentNumber = Random().nextInt(100); // Value is >= 0 and < 10.
  }
}
