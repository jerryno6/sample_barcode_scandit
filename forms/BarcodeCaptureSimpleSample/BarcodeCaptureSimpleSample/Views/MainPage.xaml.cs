/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using BarcodeCaptureSimpleSample.ViewModels;
using Scandit.DataCapture.Barcode.UI.Unified;
using Scandit.DataCapture.Core.UI.Unified;
using Xamarin.Forms;

namespace BarcodeCaptureSimpleSample.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel viewModel;
        private DataCaptureView dataCaptureView;

        public MainPage()
        {
            this.InitializeComponent();
            this.viewModel = this.BindingContext as MainPageViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var overlay = new BarcodeCaptureOverlay()
            {
                BarcodeCapture = viewModel.BarcodeCapture,
                Viewfinder = viewModel.Viewfinder,
                Style = BarcodeCaptureOverlayStyle.Frame
            };

            dataCaptureView = new DataCaptureView()
            {
                HeightRequest = 400
            };
            dataCaptureView.AddOverlay(overlay);

            _stacklayout.Children.Add(dataCaptureView);

            _ = viewModel.OnResumeAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.viewModel.OnSleep();

            _stacklayout.Children.RemoveAt(1);
            dataCaptureView = null;
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
    }
}
