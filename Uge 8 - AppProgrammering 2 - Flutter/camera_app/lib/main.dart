import 'dart:typed_data'; // Enable additional file types
import 'dart:convert'; // Convert to Base64
import 'dart:io'; // Read file data

import 'package:flutter/material.dart'; // Grant us nice UI elements
import 'package:go_router/go_router.dart'; // Enable routing between screens
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:camera_app/cameraBloc/camera_bloc.dart'; // Access camera bloc

import 'package:camera/camera.dart'; // Access to the camera sensor
import 'package:localstorage/localstorage.dart'; // Persist data

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();
  _cameras = await availableCameras();

  runApp(const MyApp());
}

/// The route configuration.
final GoRouter _router = GoRouter(
  routes: <RouteBase>[
    // Set up routes in a list, that provides a id/path for each screen
    GoRoute(
      path: '/',
      builder: (BuildContext context, GoRouterState state) {
        return const MyHomePage(title: "Startside");
      },
      routes: <RouteBase>[
        GoRoute(
          path: 'takePictureScreen',
          builder: (BuildContext context, GoRouterState state) {
            return const CameraApp();
          },
        ),
        GoRoute(
          path: 'viewPictureScreen',
          builder: (BuildContext context, GoRouterState state) {
            return const ViewPictureScreen(title: "Se dine billeder!");
          },
        ),
        GoRoute(
          path: 'favoritesScreen',
          builder: (BuildContext context, GoRouterState state) {
            return const FavoritesScreen();
          },
        ),
      ],
    ),
  ],
);

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp.router(
      routerConfig: _router,
      title: 'Flutter Demo',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
        useMaterial3: true,
      ),
      // home: const StatefulApp(title: 'Flutter Demo Home Page'), // Commented out as it's not a valid property of MaterialApp.router
      builder: (context, router) {
        return MultiBlocProvider(
          providers: [
            BlocProvider<CameraBloc>(
              create: (BuildContext context) => CameraBloc(),
            ),
          ],
          child: router!,
        );
      },
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key, required this.title});
  final String title;
  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text(widget.title)),
      drawer: Drawer(
        // Add a ListView to the drawer. This ensures the user can scroll
        // through the options in the drawer if there isn't enough vertical
        // space to fit everything.
        child: ListView(
          // Important: Remove any padding from the ListView.
          padding: EdgeInsets.zero,
          children: [
            const DrawerHeader(
              decoration: BoxDecoration(
                color: Colors.blue,
              ),
              child: Text('Drawer Header'),
            ),
            ListTile(
              title: const Text('Home'),
              onTap: () {
                // Update the state of the app
                context.go('/');
                // Then close the drawer
                Navigator.pop(context);
              },
            ),
            ListTile(
              title: const Text('Tag Billede'),
              onTap: () {
                // Update the state of the app
                context.go('/takePictureScreen');
                // Then close the drawer
                Navigator.pop(context);
              },
            ),
            ListTile(
              title: const Text('Se billeder'),
              onTap: () {
                // Update the state of the app
                context.go('/viewPictureScreen');
                // Then close the drawer
                Navigator.pop(context);
              },
            ),
            ListTile(
              title: const Text('Arranger Favoritter'),
              onTap: () {
                // Update the state of the app
                context.go('/favoritesScreen');
                // Then close the drawer
                Navigator.pop(context);
              },
            ),
          ],
        ),
      ),
    );
  }
}

//region TakePictureScreen
class TakePictureScreen extends StatefulWidget {
  const TakePictureScreen({super.key, required this.title});
  final String title;
  @override
  State<TakePictureScreen> createState() => _TakePictureScreenState();
}

class _TakePictureScreenState extends State<TakePictureScreen> {
  int _counter = 0;

  void _incrementCounter() {
    setState(() {
      _counter++;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        // Here we take the value from the MyHomePage object that was created by
        // the App.build method, and use it to set our appbar title.
        title: Text(widget.title),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            const Text(
              'You have pushed the button this many times:',
            ),
            Text(
              '$_counter',
              style: Theme.of(context).textTheme.headlineMedium,
            ),
          ],
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: _incrementCounter,
        tooltip: 'Increment',
        child: const Icon(Icons.add),
      ),
    );
  }
}
//endregion

//region TakePictureScreen
class ViewPictureScreen extends StatefulWidget {
  const ViewPictureScreen({super.key, required this.title});
  final String title;
  @override
  State<ViewPictureScreen> createState() => _ViewPictureScreenState();
}

class _ViewPictureScreenState extends State<ViewPictureScreen> {
  final LocalStorage storage = LocalStorage('camera_app_images.json');
  List<Uint8List> images = [];

  @override
  void initState() {
    super.initState();
    loadImages();
  }

  void loadImages() async {
    await storage.ready;
    var base64ImagesFromStorage = storage.getItem('images');
    List<String> base64Images = base64ImagesFromStorage != null
        ? List<String>.from(base64ImagesFromStorage)
        : [];
    images =
        base64Images.map((base64Image) => base64Decode(base64Image)).toList();
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('View Pictures'),
      ),
      body: GridView.builder(
        gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
          crossAxisCount: 3, // number of items per row
          mainAxisSpacing: 20,
        ),
        itemCount: images.length,
        itemBuilder: (context, index) {
          return InkWell(
            onTap: () {
              Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) =>
                      FullScreenImageScreen(image: images[index]),
                ),
              );
            },
            child: Image.memory(images[index]),
          );
        },
      ),
    );
  }
}

class FullScreenImageScreen extends StatelessWidget {
  final Uint8List image;

  FullScreenImageScreen({required this.image});

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        Navigator.pop(context);
      },
      child: Center(
        child: Image.memory(image),
      ),
    );
  }
}

//endregion

late List<CameraDescription> _cameras;

/// CameraApp is the Main Application.
class CameraApp extends StatefulWidget {
  /// Default Constructor
  const CameraApp({super.key});

  @override
  State<CameraApp> createState() => _CameraAppState();
}

class _CameraAppState extends State<CameraApp> {
  late CameraController controller;
  Uint8List imageData = Uint8List(0);
  String imageString = "";
  final LocalStorage storage = LocalStorage('camera_app_images.json');
  List<String> images = [];

  @override
  void initState() {
    super.initState();
    controller = CameraController(_cameras[0], ResolutionPreset.max);
    var imagesFromStorage = storage.getItem('images');
    images =
        imagesFromStorage != null ? List<String>.from(imagesFromStorage) : [];
    controller.initialize().then((_) {
      if (!mounted) {
        return;
      }
      setState(() {});
    }).catchError((Object e) {
      if (e is CameraException) {
        switch (e.code) {
          case 'CameraAccessDenied':
            // Handle access errors here.
            break;
          default:
            // Handle other errors here.
            break;
        }
      }
    });
  }

  @override
  void dispose() {
    controller.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    if (!controller.value.isInitialized) {
      return Container();
    }
    return MaterialApp(
      home: Column(
        children: [
          CameraPreview(controller),
          Padding(
            padding:
                const EdgeInsets.only(top: 10.0), // Adjust the value as needed
            child: Row(
              children: [
                FloatingActionButton(
                    heroTag: "BackButton",
                    child: const Icon(Icons.arrow_back),
                    onPressed: () {
                      Navigator.pop(context);
                    }),
                const SizedBox(width: 10),
                FloatingActionButton(
                    heroTag: "GalleryButton",
                    child: const Icon(Icons.image_search),
                    onPressed: () {
                      Navigator.pop(context);
                      context.go('/viewPictureScreen');
                    }),
              ],
            ),
          ),
          FloatingActionButton(
            heroTag: "TakePictureButton",
            shape: CircleBorder(),
            onPressed: () async {
              XFile file = await controller.takePicture();
              print('Picture saved at ${file.path}');

              // Read the file
              imageData = await File(file.path).readAsBytes();

              // Convert to base64
              imageString = base64Encode(imageData);
              print('Base64 string: $imageString');

              // Get the list of images from localstorage, or initialize a new list if it's null
              List<String> images = (storage.getItem('images') as List<dynamic>)
                  .cast<
                      String>(); // We need it to be dynamic, otherwise we get a type mismatch

              // Add the new image to the list
              images.add(imageString);

              // Save the list back to localstorage
              await storage.ready;
              storage.setItem('images', images);

              // Update the UI
              setState(() {});
            },
            child: (const Icon(Icons.camera_alt)),
          ),
          if (images.isNotEmpty)
            Padding(
              padding:
                  const EdgeInsets.only(top: 3.0), // Adjust the value as needed
              child: Container(
                height: 30, // Set the height of the ListView
                child: ListView.builder(
                  scrollDirection: Axis.horizontal,
                  itemCount: images.length,
                  itemBuilder: (context, index) {
                    return Container(
                      width: 60, // Set the width of each image
                      child: Image.memory(base64Decode(images[index]),
                          fit: BoxFit.cover),
                    );
                  },
                ),
              ),
            ),
        ],
      ),
    );
  }
}

class FavoritesScreen extends StatefulWidget {
  const FavoritesScreen({super.key});

  @override
  State<FavoritesScreen> createState() => _FavoritesScreenState();
}

class DroppedItem {
  final Widget widget;
  final Offset position;
  final Uint8List imageData;

  DroppedItem(
      {required this.widget, required this.position, required this.imageData});
}

class _FavoritesScreenState extends State<FavoritesScreen> {
  final LocalStorage storage = LocalStorage('camera_app_images.json');
  List<String> images = [];

  @override
  void initState() {
    super.initState();
    loadImages();
  }

  void loadImages() async {
    await storage.ready;
    var base64ImagesFromStorage = storage.getItem('images');
    images = base64ImagesFromStorage != null
        ? List<String>.from(base64ImagesFromStorage)
        : [];
    setState(() {});
  }

  List<DroppedItem> droppedItems = [];
  @override
  Widget build(BuildContext context) {
    return Column(
      children: <Widget>[
        Container(
          height: MediaQuery.of(context).size.height * 0.7,
          width: MediaQuery.of(context).size.width,
          decoration: BoxDecoration(
            image: droppedItems.isNotEmpty
                ? DecorationImage(
                    image: MemoryImage(droppedItems.last.imageData),
                    fit: BoxFit.cover,
                  )
                : null,
          ),
          child: Stack(
            children: droppedItems.map((droppedItem) {
              return Positioned(
                left: droppedItem.position.dx,
                top: droppedItem.position.dy,
                child: droppedItem.widget,
              );
            }).toList(),
          ),
        ),
        Container(
          height: MediaQuery.of(context).size.height * 0.3,
          color: Color.fromARGB(255, 59, 50, 112),
          child: ListView.builder(
            scrollDirection: Axis.horizontal,
            itemCount: images.length,
            itemBuilder: (context, index) {
              Uint8List imageData = base64Decode(images[index]);

              Widget imageWidget = SizedBox(
                width: 60,
                child: Image.memory(
                  imageData,
                  height: MediaQuery.of(context).size.height * 0.3,
                ),
              );
              return LongPressDraggable<Widget>(
                data: imageWidget,
                feedback: imageWidget,
                child: imageWidget,
                onDragEnd: (details) {
                  setState(() {
                    droppedItems.add(DroppedItem(
                      widget: imageWidget,
                      position: details.offset,
                      imageData: imageData,
                    ));
                  });
                },
              );
            },
          ),
        )
      ],
    );
  }
}
