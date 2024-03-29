import 'package:flutter/material.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        // This is the theme of your application.
        //
        // TRY THIS: Try running your application with "flutter run". You'll see
        // the application has a purple toolbar. Then, without quitting the app,
        // try changing the seedColor in the colorScheme below to Colors.green
        // and then invoke "hot reload" (save your changes or press the "hot
        // reload" button in a Flutter-supported IDE, or press "r" if you used
        // the command line to start the app).
        //
        // Notice that the counter didn't reset back to zero; the application
        // state is not lost during the reload. To reset the state, use hot
        // restart instead.
        //
        // This works for code too, not just values: Most code changes can be
        // tested with just a hot reload.
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
        useMaterial3: true,
      ),
      home: const MyWidget(title: 'Flutter Demo Home Page'),
    );
  }
}

class MyWidget extends StatefulWidget {
  const MyWidget({super.key, required this.title});

  // This widget is the home page of your application. It is stateful, meaning
  // that it has a State object (defined below) that contains fields that affect
  // how it looks.

  // This class is the configuration for the state. It holds the values (in this
  // case the title) provided by the parent (in this case the App widget) and
  // used by the build method of the State. Fields in a Widget subclass are
  // always marked "final".

  final String title;

  @override
  State<MyWidget> createState() => _MyWidgetState();
}

class _MyWidgetState extends State<MyWidget> {
  List<Widget> droppedItems = [];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('DraggableScrollableSheet Demo')),
      body: Stack(
        children: [
          DraggableScrollableSheet(
            initialChildSize: 0.6,
            minChildSize: 0.5,
            maxChildSize: 1.0,
            builder: (BuildContext context, ScrollController scrollController) {
              return Container(
                color: Colors.blue[100],
                child: DragTarget<String>(
                  builder: (context, candidateData, rejectedData) {
                    return Container();
                  },
                  onWillAcceptWithDetails: (data) => true,
                  onAcceptWithDetails: (data) {
                    // The drop position will be set in the onDragEnd callback of the Draggable widget
                  },
                ),
              );
            },
          ),
          ...droppedItems,
        ],
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {},
        child: Draggable<String>(
          data: 'Draggable item',
          child: Icon(Icons.drag_handle),
          feedback: const Icon(Icons.drag_handle),
          onDragEnd: (details) {
            setState(() {
              droppedItems.add(Positioned(
                left: details.offset.dx,
                top: details.offset.dy,
                child: const Icon(Icons.drag_handle),
              ));
            });
          },
        ),
      ),
    );
  }
}
