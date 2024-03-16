import 'package:flutter_test/flutter_test.dart';
import 'package:camera_app/main.dart';

void main() {
  testWidgets('Drawer contains header with text "Drawer Header"',
      (WidgetTester tester) async {
    // Build our app and trigger a frame.
    await tester.pumpWidget(MyHomePage(title: "Startside"));

    // Open the drawer
    await tester.tap(find.byTooltip('Open navigation menu'));
    await tester.pumpAndSettle();

    // Verify that the drawer contains the header with the text 'Drawer Header'
    expect(find.text('Drawer Header'), findsOneWidget);
  });
}
