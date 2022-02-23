# Workaround for Scandit DataCaptureView issue "consecutive scanner screens"

Note: This bug only happens in Android. iOS works as expected.
1. Tap "Test" button to navigate to the second scanner page.
2. Tap Back button to go back.
3. The first scanner page no longer works.

Workaround:
1. OnAppearing: create new BarcodeCaptureOverlay and add it to View
2. OnDisappearing: remove BarcodeCaptureOverlay from the view and dispose it.
