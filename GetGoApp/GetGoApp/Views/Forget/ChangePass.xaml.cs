using GetGoApp.Class;
using GetGoApp.Views.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetGoApp.Views.Forget
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePass : ContentPage
    {
        private string link, weblink;
        public ChangePass()
        {
            try
            {
                InitializeComponent();

                link = "http://192.168.1.19/GetGo";
                weblink = $"{link}/Views/UserApp/Signup/Change_Password.aspx";
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
        private async void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            // Check if the navigation was successful and the URL is not null or empty
            if (e.Result == WebNavigationResult.Success && !string.IsNullOrEmpty(e.Url))
            {
                if (e.Url.Contains("?RESPONSE=Success"))
                {
                    PrimaryButton.Text = "Verify";
                    //PrimaryButton.TextColor = Color.White;
                    await DisplayAlert("Success", "Please input your verification code", "OK");
                    //await Navigation.PushAsync(new Profile_Primary());
                    // Do something with the query string values here...
                }
                else if (e.Url.Contains("?RESPONSE=Verified"))
                {
                  
                }
                else
                {
                    await DisplayAlert("Error", "Please Try Again!", "OK");
                }
   
            }
            else
            {
                await DisplayAlert("Error", "Please Try Again!", "OK");
            }
        }

        private void PrimaryButton_Clicked(object sender, EventArgs e)
        {
            if (PrimaryButton.Text == "Proceed")
            {
                webView.EvaluateJavaScriptAsync("GetUserID();");
                webView.Navigated += WebView_Navigated;
            }
            else
            {
                PrimaryButton.IsEnabled = false;
            }


        }
    }
}