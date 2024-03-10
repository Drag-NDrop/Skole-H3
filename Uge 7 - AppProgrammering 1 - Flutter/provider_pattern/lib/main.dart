//region Imports
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:go_router/go_router.dart';

import 'package:provider_pattern/counter_change/bloc/counter_change_bloc.dart';
import 'package:provider_pattern/counter_change/event/counter_change_event.dart';
import 'package:provider_pattern/counter_change/state/counter_change_state.dart';

import 'package:provider_pattern/randombloc/bloc/random_bloc.dart';
import 'package:provider_pattern/randombloc/event/random_number_event.dart';
import 'package:provider_pattern/randombloc/state/random_number_state.dart';

import 'package:provider_pattern/geometrybloc/bloc/msr_geometry_bloc.dart';

//endregion
void main() {
  runApp(const MyApp());
}
/// The route configuration.
//region GoRouter _router
final GoRouter _router = GoRouter(
  routes: <RouteBase>[
    GoRoute(
      path: '/',
      builder: (BuildContext context, GoRouterState state) {
        return const StatefulApp(title: "Test App",);
      },
      routes: <RouteBase>[
        GoRoute(
          path: 'ProviderPatternTest',
          builder: (BuildContext context, GoRouterState state) {
            return const ProviderScreen();
          },
        ),
     /*   GoRoute(
          path: 'randomNumber',
          builder: (BuildContext context, GoRouterState state) {
            return const RandomNumberScreen();
          },
        ),
        */
        GoRoute(
          path: 'ProviderPatternTestScreen',
          builder: (BuildContext context, GoRouterState state) {
            return const ProviderPatternTestScreen();
          },
        ),
        GoRoute(
          path: 'BlocPatternTestScreen',
          builder: (BuildContext context, GoRouterState state) {
            return const BlocPatternTestScreen();
          },
        ),
        GoRoute(
          path: 'RandomNumberTestScreen',
          builder: (BuildContext context, GoRouterState state) {
            return const RandomNumberTestScreen();
          },
        ), GoRoute(
          path: 'GeometryTesting',
          builder: (BuildContext context, GoRouterState state) {
            return const GeometryTestScreen();
          },
        ),
      ],
    ),
  ],
);
//endregion



//region MyApp
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
        // useMaterial3: true, // Commented out as it's not a valid ThemeData property
      ),
      // home: const StatefulApp(title: 'Flutter Demo Home Page'), // Commented out as it's not a valid property of MaterialApp.router
     builder: (context, router) {
        return MultiBlocProvider(
          providers: [
            BlocProvider<CounterChangeBloc>(
              create: (BuildContext context) => CounterChangeBloc(),
            ),            
            BlocProvider<RandomNumberBloc>(
              create: (BuildContext context) => RandomNumberBloc(),
            ),
            BlocProvider<MsrGeometryBloc>(
              create: (BuildContext context ) => MsrGeometryBloc())
          ],
          child: router!,
        );
      },

    );
  }
}
//endregion

//region StatefulApp
class StatefulApp extends StatefulWidget {
  const StatefulApp({super.key, required this.title});
  final String title;

  @override
  State<StatefulApp> createState() => _StatefulAppState();
  
}
//endregion

//region _StatefulAppState
class _StatefulAppState extends State<StatefulApp> {
  int _counter = 0;

  void _incrementCounter() {
    setState(() {
         _counter++;
    });
  }

  void _decrementCounter() {
    setState(() {
      _counter--;
    });
  }

 

  @override
  Widget build(BuildContext context) {
    final CounterChangeBloc counterBloc = BlocProvider.of<CounterChangeBloc>(context);
    return Scaffold(
      appBar: AppBar( // Create the App bar widget
        backgroundColor: Theme.of(context).colorScheme.inversePrimary, // Give the widget a background color
        title: Text(widget.title),  // Give the widget a title
      ),
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
              child: Text('Martins Flutter Learning'),
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
              title: const Text('ProviderPattern'),
              onTap: () {
                // Update the state of the app
                context.go('/ProviderPatternTest');
                Navigator.pop(context);
              },
            ),
            ListTile(
              title: const Text('RandomNumber'),
              //selected: _selectedIndex == 2,
              onTap: () {
                // Update the state of the app
                context.go('/randomNumber');
                // Then close the drawer
                Navigator.pop(context);
              },
            ),
            ListTile(
              title: const Text('Provider Pattern Test'),
              //selected: _selectedIndex == 2,
              onTap: () {
                // Update the state of the app
                context.go('/ProviderPatternTestScreen');
                // Then close the drawer
                Navigator.pop(context);
              },
            ),
            ListTile(
              title: const Text('Bloc Pattern Test'),
              //selected: _selectedIndex == 2,
              onTap: () {
                // Update the state of the app
                context.go('/BlocPatternTestScreen');
                // Then close the drawer
                Navigator.pop(context);
              },
            ),
            ListTile(
              title: const Text('Random Number Test'),
              //selected: _selectedIndex == 2,
              onTap: () {
                // Update the state of the app
                context.go('/RandomNumberTestScreen');
                // Then close the drawer
                Navigator.pop(context);
              },
            ),
            ListTile(
              title: const Text('Geometry Test'),
              //selected: _selectedIndex == 2,
              onTap: () {
                // Update the state of the app
                context.go('/GeometryTesting');
                // Then close the drawer
                Navigator.pop(context);
              },
            ),
          ],
        ),
      ),
      
     /* body: Center( // Center the body
        child: Column( // Add a child column
          mainAxisAlignment: MainAxisAlignment.center, 
          children: <Widget>[ 
            const Text(
              'You have pushed the button this many times:',
            ),
            BlocBuilder<CounterChangeBloc, CounterChangeState>( // Insert a blocBuilder that looks for state change events
            builder: (context, state) { // What to do when a change is found(rewrite this)
              return Text(
                '${state.currentValue}',
                style: Theme.of(context).textTheme.headlineMedium,
              );
            },
          ),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[
                FloatingActionButton.large(
                  heroTag: "button1",
                  onPressed: () {counterBloc.add(CounterIncrementEvent());},   // Increment the value of the int in the bloc
                  child: const Icon(Icons.add)),
                const SizedBox(width: 10), // Optional: to give some space between the buttons
                FloatingActionButton.large(
                  heroTag: "button2",
                  onPressed: () { counterBloc.add(CounterDecrementEvent()); }, // Decrement the value of the bloc
                  child: const Icon(Icons.remove)),
              ],
            ),
  //          FloatingActionButton.large(onPressed: _incrementCounter, child: const Icon(Icons.add)),
  //          FloatingActionButton.large(onPressed: _incrementCounter, child: const Icon(Icons.remove))

          ],
        ),
      ),
      floatingActionButton: FloatingActionButton(
        heroTag: "button3",
        onPressed: () => context.go('/ProviderPatternTest'),
        tooltip: 'Increment',
        child: const Icon(Icons.add),
      ), // This trailing comma makes auto-formatting nicer for build methods.
      */
    );
  }
}
//endregion

//region ProviderPattern
class ProviderPattern extends StatefulWidget {
  const ProviderPattern({super.key, required this.title});
  final String title;
  @override
  State<StatefulApp> createState() => _StatefulAppState();
}
//endregion

//region ProviderScreen
class ProviderScreen extends StatelessWidget {
  /// Constructs a [ProviderScreen]
  const ProviderScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Details Screen')),
      body: Center(
        child: Row(
        children: <Widget>[
          ElevatedButton(
            onPressed: () => context.go('/'),
            child: const Text('Home screen'),
          ),
          ElevatedButton(
            onPressed: () => context.go('/randomNumber'),
            child: const Text('Random number screen'),
          ),
        ]
        )
      ),
    );
  }
}
//endregion

/*
//region RandomNumberScreen
class RandomNumberScreen extends StatefulWidget {
  const RandomNumberScreen({super.key});

  @override
  State<RandomNumberScreen> createState() => _RandomNumberScreenState();
}
// endregion

//region
class _RandomNumberScreenState extends State<RandomNumberScreen> {
 
}
//endregion
*/

//region ProviderPatternTestScreen
class ProviderPatternTestScreen extends StatefulWidget {
  const ProviderPatternTestScreen({super.key});

  @override
  State<ProviderPatternTestScreen> createState() => _ProviderPatternTestScreenState();
}

class _ProviderPatternTestScreenState extends State<ProviderPatternTestScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('New Widget')),
      body: Center(
        child: Text(
          'This is a new widget',
          style: Theme.of(context).textTheme.headlineMedium,
        ),
      ),
    );
  }
}
//endregion

//region BlocPatternTestScreen
class BlocPatternTestScreen extends StatefulWidget {
  const BlocPatternTestScreen({super.key});

  @override
  State<BlocPatternTestScreen> createState() => _BlocPatternTestScreenState();
}

class _BlocPatternTestScreenState extends State<BlocPatternTestScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('New Widget')),
      body: Center(
        child: Text(
          'This is a new widget',
          style: Theme.of(context).textTheme.headlineMedium,
        ),
      ),
    );
  }
}
//endregion


//region RandomNumberTestScreen
class RandomNumberTestScreen extends StatefulWidget {
  const RandomNumberTestScreen({super.key});

  @override
  State<RandomNumberTestScreen> createState() => _RandomNumberTestScreenState();
}

class _RandomNumberTestScreenState extends State<RandomNumberTestScreen> {
  @override
  Widget build(BuildContext context) {
    final RandomNumberBloc randomBloc = BlocProvider.of<RandomNumberBloc>(context);
    return Scaffold(
      appBar: AppBar(title: const Text('RandomNumber Screen')),
      body: Center( // Center the body
        child: Column( // Add a child column
          mainAxisAlignment: MainAxisAlignment.center, 
          children: <Widget>[ 
            BlocBuilder<RandomNumberBloc, RandomNumberState>( // Insert a blocBuilder that looks for state change events
            builder: (context, state) { // What to do when a change is found(rewrite this)
              return Text(
                '${state.currentValue}',
                style: Theme.of(context).textTheme.headlineMedium,
              );
            },
          ),
            const Text(
              'You have pushed the button this many times:',
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[

                FloatingActionButton.large(
                  heroTag: "button0",
                  onPressed: () {randomBloc.add(NewRandomEvent());},   // Increment the value of the int in the bloc
                  child: const Text('Start Random')),
                const SizedBox(width: 10), // Optional: to give some space between the buttons

            BlocBuilder<RandomNumberBloc, RandomNumberState>( // Insert a blocBuilder that looks for state change events
            builder: (context, state) { // What to do when a change is found(rewrite this)
                return FloatingActionButton.large(
                  heroTag: "button1",
                  onPressed: () {
                    randomBloc.add(RandomIncrementEvent());
                  },
                  child: randomBloc.state.currentValue <= 1
                      ? const Icon(Icons.dangerous_rounded,
                        color: Colors.red
                        )
                      : const Icon(
                        Icons.add,
                      ),
                );
                },
),
              
                  /*Icon(Icons.add)*/
            
                const SizedBox(width: 10), // Optional: to give some space between the buttons

                FloatingActionButton.large(
                  heroTag: "button2",
                  onPressed: () { randomBloc.add(RandomDecrementEvent()); }, // Decrement the value of the bloc
                  child: const Icon(Icons.remove)),
              ],
            ),
  //          FloatingActionButton.large(onPressed: _incrementCounter, child: const Icon(Icons.add)),
  //          FloatingActionButton.large(onPressed: _incrementCounter, child: const Icon(Icons.remove))

          ],
        ),
      ),
    );
  }
}
//endregion



//region GeometryTestScreen
class GeometryTestScreen extends StatefulWidget {
  const GeometryTestScreen({super.key});

  @override
  State<GeometryTestScreen> createState() => _GeometryTestScreenState();
}

class _GeometryTestScreenState extends State<GeometryTestScreen> {
  @override
  Widget build(BuildContext context) {
    final MsrGeometryBloc geometryBloc = BlocProvider.of<MsrGeometryBloc>(context);
    return Scaffold(
      appBar: AppBar(title: const Text('New Widget')),
      body: Center(
        child: Column(
          children: <Widget>[ 
        Text(
          'Geometry test',
          style: Theme.of(context).textTheme.headlineMedium,
        ),
        
         BlocBuilder<MsrGeometryBloc, GeometryShape>(
          builder: (context, state) { // What to do when a change is found(rewrite this)
              return state.shapeDetails;
              /*return Text(
                '${state.shapeDetails}',
                style: Theme.of(context).textTheme.headlineMedium,
              );
              */
            },
            
         ),
         FloatingActionButton(
              heroTag: "button6",
              onPressed: () => geometryBloc.add(NewTriangleEvent()),
              child: const Text("New triangle"),
            ),
         ],  
      ),
      ),
    );
  }
}
//endregion