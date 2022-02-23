# Workaround for Scandit DataCaptureView issue "consecutive scanner screens"

Note: This bug only happens in Android. iOS works as expected.
1. Open a xaml Page which contains DataCaptureView -> The DataCaptureView works this time.
2. Navigate to another page which also contains DataCaptureView. -> The DataCaptureView works this time.
3. Click on BackButton (or call Navigation.Pop()) to remove the 2nd page from the stack and return back to the 1st page -> DataCaptureView stops working.

*Workaround from Scandit*: make sure that the current DataCaptureView is the last one created on the UI navigation stack. 
1. remove the first page from the Navigation Stack before navigating to the second one, 
2. Add it back when the second page loads.
-> The problem is that if you don't want to remove/pop the 1st page from the navigation stack, you can use the workaround below.

*Workaround from me*: We will not remove the page from NavigationStack, but only need to remove the BarcodeCaptureOverlay from the page before navigating to another page.
1. OnAppearing: create new BarcodeCaptureOverlay and add it to View
2. OnDisappearing: remove BarcodeCaptureOverlay from the view and dispose it.
