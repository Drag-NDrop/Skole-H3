import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:go_router/go_router.dart';

import 'package:provider_pattern/counter_change/bloc/counter_change_bloc.dart';
import 'package:provider_pattern/counter_change/event/counter_change_event.dart';
import 'package:provider_pattern/counter_change/state/counter_change_state.dart';

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
            )
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
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        title: Text(widget.title),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            const Text(
              'You have pushed the button this many times:',
            ),
            BlocBuilder<CounterChangeBloc, CounterChangeState>(
            builder: (context, state) {
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
                  onPressed: () {counterBloc.add(CounterIncrementEvent());},  
                  child: const Icon(Icons.add)),
                const SizedBox(width: 10), // Optional: to give some space between the buttons
                FloatingActionButton.large(
                  heroTag: "button2",
                  onPressed: () { counterBloc.add(CounterDecrementEvent()); }, // CounterChangeBloc().add(CounterDecrementEvent()) ,//_decrementCounter, 
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
        child: ElevatedButton(
          onPressed: () => context.go('/'),
          child: const Text('Go back to the Home screen'),
        ),
      ),
    );
  }
}