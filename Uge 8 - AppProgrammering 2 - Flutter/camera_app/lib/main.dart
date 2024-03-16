import 'package:camera_app/cameraBloc/camera_bloc.dart'; // Access camera bloc
import 'package:camera_app/cameraBloc/camera_event.dart'; // Access relevant events for camera bloc
import 'package:camera_app/cameraBloc/camera_state.dart'; // Access camera bloc state

import 'package:camera_app/repository/local_image_repository.dart';
import 'package:camera_app/repository/remote_image_respository.dart';

import 'package:camera_app/screens/ViewPictureScreen.dart';
import 'package:camera_app/screens/TakePictureScreen.dart';
import 'package:camera_app/screens/FavoritesScreen.dart';

import 'package:flutter/material.dart'; // Grant us nice UI elements
import 'package:go_router/go_router.dart'; // Enable routing between screens
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_spinkit/flutter_spinkit.dart';

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();
  BlocProvider<CameraBloc>(
    create: (BuildContext context) => CameraBloc(),
  );
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
            return TakePictureScreen();
          },
        ),
        GoRoute(
          path: 'viewPictureScreen',
          builder: (BuildContext context, GoRouterState state) {
            return ViewPictureScreen();
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
    final CameraBloc cameraBloc = BlocProvider.of<CameraBloc>(context);
    return Scaffold(
      appBar: AppBar(title: Text(widget.title)),
      drawer: Drawer(
        // Add a ListView to the drawer. This ensures the user can scroll
        // through the options in the drawer if there isn't enough vertical
        // space to fit everything.
        child: ListView(
          // Remove any padding from the ListView.
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
                // Navigate to screen
                context.go('/');
                // Then close the drawer
                Navigator.pop(context);
              },
            ),
            ListTile(
              title: const Text('Tag Billede'),
              onTap: () {
                // Navigate to screen
                context.go('/takePictureScreen');
                // Then close the drawer
                Navigator.pop(context);
              },
            ),
            ListTile(
              title: const Text('Se billeder'),
              onTap: () {
                // Navigate to screen
                context.go('/viewPictureScreen');
                // Then close the drawer
                Navigator.pop(context);
              },
            ),
            ListTile(
              title: const Text('Arranger Favoritter'),
              onTap: () {
                // Navigate to screen
                context.go('/favoritesScreen');
                // Then close the drawer
                Navigator.pop(context);
              },
            ),
            ListTile(
              title: const Text('Contact API'),
              onTap: () {
                // Purely a menu item for testing..
                // Get the CameraBloc
                //final cameraBloc = BlocProvider.of<CameraBloc>(context);
                cameraBloc.add(LoadPicturesEvent());
                // Then close the drawer
                Navigator.pop(context);
              },
            ),
          ],
        ),
      ),
      body: Center(
        child: Column(
          children: [
            Text(
                "Cloud repository enabled: ${cameraBloc.state.settings.getRepositoryChoice}"),
            Switch(
              // thumb color (round icon)
              activeColor: Colors.amber,
              activeTrackColor: Colors.cyan,
              inactiveThumbColor: Colors.blueGrey.shade600,
              inactiveTrackColor: Colors.grey.shade400,
              splashRadius: 50.0,
              // boolean variable value
              value: cameraBloc.state.settings.getRepositoryChoice,
              // changes the state of the switch
              onChanged: (value) => setState(
                  () => cameraBloc.state.settings.repositoryChoice = value),
            ),
            FloatingActionButton(
              heroTag: "SwitchStorageMethodButton",
              onPressed: () {
                if (cameraBloc.state.settings.repositoryChoice == true) {
                  cameraBloc
                      .add(ReloadPicturesEvent(desiredRepository: 'remote'));
                } else {
                  cameraBloc
                      .add(ReloadPicturesEvent(desiredRepository: 'local'));
                }
                setState(() {});
              },
              child: Icon(Icons.threesixty_rounded),
            ),
          ],
        ),
      ),
    );
  }
}

//region ViewPictureScreen

//endregion
