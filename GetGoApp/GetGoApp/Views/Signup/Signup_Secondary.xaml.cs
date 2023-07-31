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
                if (detailsArray.Length >= 2)
               {
                    userName = detailsArray[1];
                    phoneNumber = detailsArray[2];
                    email = detailsArray[3];
                }
            }
            if (!string.IsNullOrEmpty(link))
            {
                webView.Source = new UrlWebViewSource 
                { Url = $"{link}/Views/UserApp/Signup/Signup_Secondary.aspx?UserName={userName}&PhoneNumber={phoneNumber}&Email={email}" };
            }

            
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            webView.EvaluateJavaScriptAsync("SaveClick();");
            webView.Navigated += WebView_Navigated;
        }
        private  void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            // Check if the navigation was successful and the URL is not null or empty
            if (e.Result == WebNavigationResult.Success && !string.IsNullOrEmpty(e.Url))
            {
                // Get the query string parameters from the URL
                var uri = new Uri(e.Url);
                var queryParameters = System.Web.HttpUtility.ParseQueryString(uri.Query);
                var parametersDict = queryParameters.AllKeys.ToDictionary(key => key, key => queryParameters[key]);
                // Build the SignupDetails string
                string signupDetails = BuildSignupDetails(link, parametersDict);

                // Set the SignupDetails value in the global data storage class
                AppData.Instance.SignupDetails = signupDetails;

                //await Navigation.PushAsync(new Signup_Secondary());
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