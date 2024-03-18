import 'package:camera_app/main.dart';
import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:integration_test/integration_test.dart';

void main() {
  IntegrationTestWidgetsFlutterBinding.ensureInitialized();

  testWidgets('Test navigation to Home and Se billeder routes',
      (WidgetTester tester) async {
    // Load app widget.
    await tester.pumpWidget(const MyApp());

    // Open the drawer.
    await tester.tap(find.byIcon(Icons.menu));
    await tester.pumpAndSettle();
    // List of routes to test.
    var routes = ['Home', 'Se billeder'];

    for (var route in routes) {
      // Find the ListTile with the specific text.
      final tile = find.text(route);
      // Tap the menu item
      tester.tap(tile);
      // Trigger a frame.
      await tester.pumpAndSettle();
      // Insert a delay.
      await Future.delayed(const Duration(seconds: 1));
      // Simulate the Android back button press.
      await tester.binding.handlePopRoute();
      await tester.pumpAndSettle();
      // Insert a delay.
      await Future.delayed(const Duration(seconds: 1));
      /* if (tile.evaluate().isEmpty) {
        print('Could not find ListTile with text: $route');
        continue;
      }
      */
    }
  });
}
