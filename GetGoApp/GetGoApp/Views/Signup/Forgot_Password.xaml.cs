using GetGoApp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetGoApp.Views.Signup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Forgot_Password : ContentPage
    {
        private string link;
        private bool isNavigatedHandled = false;
        public Forgot_Password()
        {
            InitializeComponent();
            link = AppData.Instance.Link;

            if (!string.IsNullOrEmpty(link))
            {
                webView.Source = new UrlWebViewSource { Url = $"{link}/Views/UserApp/Signup/Change_Password.aspx" };
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            webView.EvaluateJavaScriptAsync("Save();");
            webView.Navigated += WebView_Navigated;
        }
        private async void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            // Check if the navigation was successful and the URL is not null or empty
            if (isNavigatedHandled || e.Result != WebNavigationResult.Success || string.IsNullOrEmpty(e.Url))
            {
                return;
            }

            // Set the flag to true to indicate the event has been handled
            isNavigatedHandled = true;

            // Get the query string parameters from the URL

            // Set the SignupDetails value in the global data storage class
            AppData.Instance.Link = link;
            await DisplayAlert("Success", "Go back to login", "OK");
            await Navigation.PushAsync(new Login());
            // Do something with the query string values here...
        }
    }
}
   
