import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:go_router/go_router.dart';

import 'package:provider_pattern/counter_change/bloc/counter_change_bloc.dart';
import 'package:provider_pattern/counter_change/event/counter_change_event.dart';
import 'package:provider_pattern/counter_change/state/counter_change_state.dart';

import 'package:provider_pattern/randombloc/bloc/random_bloc.dart';
import 'package:provider_pattern/randombloc/event/random_number_event.dart';
import 'package:provider_pattern/randombloc/state/random_number_state.dart';

void main() {
  runApp(const MyApp());
}
/// The route configuration.
final GoRouter _router = GoRouter(
  routes: <RouteBase>[
    GoRoute(
      path: '/',
      builder: (BuildContext context, GoRouterState state) {
        return const StatefulApp(title: "ProviderPattern",);
      },
      routes: <RouteBase>[
        GoRoute(
          path: 'providertest',
          builder: (BuildContext context, GoRouterState state) {
            return const ProviderScreen();
          },
        ),
        GoRoute(
          path: 'randomNumber',
          builder: (BuildContext context, GoRouterState state) {
            return const RandomNumberScreen();
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
          ],
          child: router!,
        );
      },
    );
  }
}

class StatefulApp extends StatefulWidget {
  const StatefulApp({super.key, required this.title});
  final String title;

  @override
  State<StatefulApp> createState() => _StatefulAppState();
  
}

class ProviderPattern extends StatefulWidget {
  const ProviderPattern({super.key, required this.title});
  final String title;

  @override
  State<StatefulApp> createState() => _StatefulAppState();
}

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
      body: Center( // Center the body
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
        onPressed: () => context.go('/providertest'),
        tooltip: 'Increment',
        child: const Icon(Icons.add),
      ), // This trailing comma makes auto-formatting nicer for build methods.
    );
  }
}

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



class RandomNumberScreen extends StatefulWidget {
  const RandomNumberScreen({super.key});

  @override
  State<RandomNumberScreen> createState() => _RandomNumberScreenState();
}

class _RandomNumberScreenState extends State<RandomNumberScreen> {
  @override
  Widget build(BuildContext context) {
    final RandomNumberBloc randomBloc = BlocProvider.of<RandomNumberBloc>(context);
    return Scaffold(
      appBar: AppBar(title: const Text('RandomNumber Screen')),
      body: Center( // Center the body
        child: Column( // Add a child column
          mainAxisAlignment: MainAxisAlignment.center, 
          children: <Widget>[ 
            const Text(
              'You have pushed the button this many times:',
            ),
            BlocBuilder<RandomNumberBloc, RandomNumberState>( // Insert a blocBuilder that looks for state change events
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
                  heroTag: "button0",
                  onPressed: () {randomBloc.add(NewRandomEvent());},   // Increment the value of the int in the bloc
                  child: const Text('Start Random')),
                const SizedBox(width: 10), // Optional: to give some space between the buttons

                FloatingActionButton.large(
                  heroTag: "button1",
                  onPressed: () {randomBloc.add(RandomIncrementEvent());},   // Increment the value of the int in the bloc
                  child: const Icon(Icons.add)),
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



