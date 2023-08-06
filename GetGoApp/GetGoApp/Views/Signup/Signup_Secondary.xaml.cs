using GetGoApp.Class;
using GetGoApp.Views.Profile;
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
    public partial class Signup_Secondary : ContentPage
    {
        private string link,signupDetails,userName,email,phoneNumber;
        public Signup_Secondary()
        {
            InitializeComponent();
            link = AppData.Instance.Link;
            signupDetails = AppData.Instance.SignupDetails;
            if (!string.IsNullOrEmpty(signupDetails))
            {
                string[] detailsArray = signupDetails.Split('|');
                if (detailsArray.Length >= 2) // Make sure there are enough elements
                {
                    userName = detailsArray[1].Replace(":", "=");
                    phoneNumber = detailsArray[2].Replace(":", "=");
                    email = detailsArray[3].Replace(":", "=");
                }
            }
            if (!string.IsNullOrEmpty(link))
            {
                webView.Source = new UrlWebViewSource
                { Url = $"{link}/Views/UserApp/Signup/Signup_Secondary.aspx?{userName}&{phoneNumber}&{email}" };
            }

            
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            webView.EvaluateJavaScriptAsync("SaveClick();");
            webView.Navigated += WebView_Navigated;
        }
        private async void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            // Check if the navigation was successful and the URL is not null or empty
            if (e.Result == WebNavigationResult.Success && !string.IsNullOrEmpty(e.Url))
            {
                await Navigation.PushAsync(new Profile_Primary());
                // Do something with the query string values here...
            }
        }
        private string BuildSignupDetails(string link, Dictionary<string, string> queryParameters)
        {
            StringBuilder signupDetails = new StringBuilder();
            signupDetails.Append($"{link}|");
            foreach (var parameter in queryParameters)
            {
                signupDetails.Append($"{parameter.Key}:{parameter.Value}|");
            }
            return signupDetails.ToString();
        }

    }
}