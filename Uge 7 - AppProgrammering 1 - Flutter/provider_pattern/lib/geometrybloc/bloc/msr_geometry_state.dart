part of 'msr_geometry_bloc.dart';

sealed class MsrGeometryState {}
/*
final class MsrGeometryInitial extends MsrGeometryState {
  return MsrGeometryState().._currentShape = Square();
}
*/


// Statehandler logic, Bloc pattern
// This class encapsulates the logic we want for the state, the bloc is brokering.
// We can fire the methods here, in the emitters in the bloc, to get the desired operations performed, based on current state of the app.
class Square extends GeometryShape{
  int get sideA => sideA;
  int get sideB => sideB;
  int get sideC => sideC;
  int get sideD => sideD;
  int _sideA = Random().nextInt(10) +1;
  int _sideB = Random().nextInt(10) +1;
  int _sideC = Random().nextInt(10) +1;
  int _sideD = Random().nextInt(10) +1;
}


class Triangle extends GeometryShape{
  int sideA = generateRandomSideLength();
  int sideB = generateRandomSideLength();
  int sideC = generateRandomSideLength();
  List<Point> coordinates = List.empty(growable: true);
  List<double> angles = List.empty(growable: true);
  List<double> radians = List.empty(growable: true);
  
  
  Triangle() { // keep generating until we have a valid triangle.
  do {
    sideA = generateRandomSideLength();
    sideB = generateRandomSideLength();
    sideC = generateRandomSideLength();
   } while (sideA + sideB <= sideC ||
            sideB + sideC <= sideA ||
            sideC + sideA <= sideB);
  }


}

int generateRandomSideLength(){ return (Random().nextInt(8) + 2); }

class Circle extends GeometryShape{
  int radius = Random().nextInt(10);
}


class GeometryShape extends MsrGeometryState{
  late GeometryShape _currentShape;
  GeometryShape get currentShape => _currentShape;
  Widget get shapeDetails => getShapeDetails();

  GeometryShape init() {
    return GeometryShape().._currentShape = newRandomShape(); // Set a default shape, used for initialization and filling the late variable
  }

  // Create a random shape and return it
  GeometryShape newRandomShape(){
    //int randomShapeInt = Random().nextInt(3) + 1;
    // Debug - Always triangles!
    int randomShapeInt = 2;
    switch (randomShapeInt) {
        case 1:
          return newSquare();
        case 2:
          return newTriangle();
        case 3:
          return newCircle();
      default:
      return newSquare();
    }
  }

  // create a new square, update the class's _currentShape with it. Return the new _currentShape reference.
  GeometryShape newSquare(){ 
    _currentShape = Square();
    return _currentShape;
  }
  
  // create a new triangle, update the class's _currentShape with it. Return the new _currentShape reference.
  GeometryShape newTriangle(){
      Triangle t = Triangle();
      _currentShape = t;      
      t.coordinates = calculateCoordinatesForTriangle(t);
      t.angles = calculateAngles(t.coordinates, t); 
      return _currentShape;
  }

  
  List<Point> calculateCoordinatesForTriangle(Triangle triangle) {

      Point pointA = Point()
          .._x = 0 // Always putting the first point at a standard position
          .._y = 0;
      Point pointB = Point()
          .._x = (_currentShape as Triangle).sideB 
          .._y= 0;

      double x = (triangle.sideC * triangle.sideC - triangle.sideB * triangle.sideB + triangle.sideA * triangle.sideA) / (2 * triangle.sideA);
      double y = sqrt(triangle.sideC * triangle.sideC - x * x);
      print(x.toString());
      print(y.toString());
      Point pointC = Point()
          .._x = x.toInt()
          .._y = y.toInt();
      
         
    
    return [pointA, pointB, pointC];
  }
  // create a new circle, update the class's _currentShape with it. Return the new _currentShape reference.
  GeometryShape newCircle(){
    _currentShape = Circle();
    return _currentShape;
  }
  
  // Figure out what shape is requested, and send back labels detailing the shapes dimensions
  Widget getShapeDetails(){
    switch(_currentShape.runtimeType){
      case Square:
        if (_currentShape is Square) {
          Square square = _currentShape as Square;
            return squareDetails(_currentShape);
        }
      case Triangle:
        Triangle triangle = _currentShape as Triangle;
       return triangleDetails(triangle);

      case Circle:
        Circle circle = _currentShape as Circle;
        return circleDetails(circle);

      default:
        return const Text('Unknown');
    }
    return const Text('Error: Couldnt exit through the switch.');
  }

  // Define the widget to return, when getShapeDetails finished the filtering
  Widget squareDetails(GeometryShape square ) {
    square as Square; // We know this function was called by logic, that classified the shape as a square. So we have no issues casting it to a square.
    return Column(
      children: <Widget>[
        Text(
          'SideA: ${square.sideA}',
          style: const TextStyle(fontSize: 24),
        ),
        Text(
          'Side B: ${square.sideB}',
          style: const TextStyle(fontSize: 24),
        ),
        Text(
          'Side C: ${square.sideC}',
          style: const TextStyle(fontSize: 24),
        ),
          Text(
          'Side D: ${square.sideD}',
          style: const TextStyle(fontSize: 24),
        ),
      ],
    );
  }

// Define the widget to return, when getShapeDetails finished the filtering. In this case, a triangle.
  Widget triangleDetails(GeometryShape triangle ) {
    triangle as Triangle; // We know this function was called by logic, that classified the shape as a triangle. So we have no issues casting it to a triangle.
    return Column(
      children: <Widget>[
        triangleDrawing(triangle as GeometryShape),
        const SizedBox(width: 10, height: 250),
        Text(
          'SideA: ${triangle.sideA}',
          style: TextStyle(fontSize: 24),
        ),
        Text(
          'Side B: ${triangle.sideB}',
          style: TextStyle(fontSize: 24),
        ),
        Text(
          'Side C: ${triangle.sideC}',
          style: TextStyle(fontSize: 24),
        ),
        Text(
          'Coordinate A.x: ${triangle.coordinates?[0]._x}  || Coordinate A.y: ${triangle.coordinates?[0]._y}',
          style: TextStyle(fontSize: 24),
        ),
          Text(
          'Coordinate B.x: ${triangle.coordinates?[1]._x}  || Coordinate B.y: ${triangle.coordinates?[1]._y}',
          style: TextStyle(fontSize: 24),
        ),
          Text(
          'Coordinate C.x: ${triangle.coordinates?[2]._x}  || Coordinate C.y: ${triangle.coordinates?[2]._y}',
          style: TextStyle(fontSize: 24),
        ),
          Text(
          'Angle A: ${triangle.angles?[0].toString()}',
          style: TextStyle(fontSize: 24),
        ),        
          Text(
          'Angle B: ${triangle.angles?[1].toString()}',
          style: TextStyle(fontSize: 24),
        ),
          Text(
          'Angle C: ${triangle.angles?[2].toString()}',
          style: TextStyle(fontSize: 24),
        ),
      ],
    );
  }
  


  Widget triangleDrawing(GeometryShape triangle ) {
      Triangle t = triangle as Triangle; // We know this function was called by logic, that classified the shape as a triangle. So we have no issues casting it to a triangle.

    return Center(
      child:
      CustomPaint(
        size: ui.Size(50, 50),
        painter: TriangleDraw(triangle),
),
    );
  }



  // Define the widget to return, when getShapeDetails finished the filtering. In this case, a circle.
    Widget circleDetails(GeometryShape circle ) {
    circle as Circle; // We know this function was called by logic, that classified the shape as a circle. So we have no issues casting it to a circle.
    return Column(
      children: <Widget>[
        Text(
          'Radius: ${circle.radius}',
          style: TextStyle(fontSize: 24),
        ),
       ],
    );
  }
 
}

// Define points in a shape(used for angle calculations)
class Point { 
        late int _x, _y; 
        init(int x, int y){
            _x = x; 
            _y = y; 
        } 
} 
      
    // returns square of distance b/w two points 
    int lengthSquare(Point p1, Point p2) 
    { 
        int xDiff = p1._x - p2._x; 
        int yDiff = p1._y - p2._y; 
        return xDiff * xDiff + yDiff * yDiff; 
    } 

    // prints the angles to console.. debug.  
    List<double> calculateAngles(List<Point> points, Triangle triangle) 
    { 
        // Square of lengths be a2, b2, c2 
        int a2 = lengthSquare(points[0], points[2]); 
        int b2 = lengthSquare(points[0], points[2]); 
        int c2 = lengthSquare(points[0], points[1]); 
          
        // length of sides be a, b, c 
      
        double a = sqrt(a2); 
        double b = sqrt(b2); 
        double c = sqrt(c2); 
          
        // From Cosine law 
        double alpha = acos((b2 + c2 - a2) / (2 * b * c)); 
        double betta = acos((a2 + c2 - b2) / (2 * a * c)); 
        double gamma = acos((a2 + b2 - c2) / (2 * a * b)); 

        triangle.radians.add(alpha);
        triangle.radians.add(betta);
        triangle.radians.add(gamma);
        // Converting to degree 
        alpha = (alpha * 180 / pi); 
        betta = (betta * 180 / pi); 
        gamma = (gamma * 180 / pi); 

        List<double> angles = List.empty(growable: true);
        angles.add(alpha);
        angles.add(betta);
        angles.add(gamma);
        return angles;
    } 




  class TriangleDraw extends CustomPainter {
  final Triangle triangle;

  TriangleDraw(this.triangle);

  @override
  void paint(Canvas canvas, ui.Size size) {
    final paint = Paint()
      ..color = Colors.black
      ..style = PaintingStyle.stroke;

    final path = Path();
    /*path.moveTo(triangle.coordinates[0]._x as double, triangle.coordinates[0]._y as double);
    path.lineTo(triangle.coordinates[1]._x as double, triangle.coordinates[1]._y as double);
    path.lineTo(triangle.coordinates[2]._x as double, triangle.coordinates[2]._y as double);
    */
    path.moveTo(triangle.coordinates[0]._x * size.width, triangle.coordinates[0]._y * size.height);
    path.lineTo(triangle.coordinates[1]._x * size.width, triangle.coordinates[1]._y * size.height);
    path.lineTo(triangle.coordinates[2]._x * size.width, triangle.coordinates[2]._y * size.height);

    path.close();

    canvas.drawPath(path, paint);
  }

  @override
  bool shouldRepaint(covariant CustomPainter oldDelegate) {
    return true;
  }
}