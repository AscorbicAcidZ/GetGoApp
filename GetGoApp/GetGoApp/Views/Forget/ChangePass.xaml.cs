using GetGoApp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetGoApp.Views.Forget
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePass : ContentPage
    {
        private string link;
        public ChangePass()
        {
            try
            {
                InitializeComponent();

                link = "http://192.168.1.7/GetGo";

                if (!string.IsNullOrEmpty(link))
                {
                    webView.Source = new UrlWebViewSource { Url = $"{link}/Views/UserApp/Signup/Change_Password.aspx" };
                    PrimaryButton.Text = "Proceed";
                }
                // Attach event handlers for WebView navigation
                webView.Navigating += OnWebViewNavigating;
                webView.Navigated += OnWebViewNavigated;

            }
            catch (Exception ex)
            {
                DisplayAlert("Access Failed", ex.ToString(), "OK");

            }

        }
        private void OnWebViewNavigating(object sender, WebNavigatingEventArgs e)
        {
            // Show the activity indicator when WebView is navigating
            loadingIndicator.IsRunning = true;
            loadingIndicator.IsVisible = true;
            GridContent.IsVisible = false;
        }

        private void OnWebViewNavigated(object sender, WebNavigatedEventArgs e)
        {
        
            // Hide the activity indicator when WebView navigation is complete
            loadingIndicator.IsRunning = false;
            loadingIndicator.IsVisible = false;
            GridContent.IsVisible = true;
        }



    }
}