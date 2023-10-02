using GetGoApp.Class;
using GetGoApp.Views.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetGoApp.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home_ApplyLoan : ContentPage
    {
        private string link, signupDetails, Details, userId;

        public Home_ApplyLoan()
        {
            InitializeComponent();
            InitializeContent();
        }
        private void InitializeContent()
        {
            try
            {
                Details = AppData.Instance.Details;
                signupDetails = AppData.Instance.Details;
                if (!string.IsNullOrEmpty(Details))
                {
                    string[] detailsArray = Details.Split('|');
                    if (detailsArray.Length >= 2)
                    {
                        link = detailsArray[0];
                        userId = detailsArray[1].Replace(":", "=");
                        WebView(link, userId);
                    }
                }
                else if (!string.IsNullOrEmpty(signupDetails))
                {
                    string[] detailsArray = Details.Split('|');
                    if (detailsArray.Length >= 2)
                    {
                        link = detailsArray[0];
                        userId = detailsArray[1];
                        WebView(link, userId);

                    }
                }
            }
            catch(Exception ex) {
                throw ex;
            }
          
          
        }
        private void WebView(string link, string input) => webView.Source = new UrlWebViewSource { Url = $"{link}/Views/UserApp/Home/ApplyLoan.aspx?{input}" };
        private void PrimaryButton_Clicked(object sender, EventArgs e)
        {
            if (PrimaryButton.Text == "Proceed")
            {
                webView.EvaluateJavaScriptAsync("Save();");
                webView.Navigated += WebView_Navigated;
            }
            else
            {
                Navigation.PushAsync(new Home_Primary());
            }
            
        }
        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            // Check if the navigation was successful and the URL is not null or empty
            if (e.Result == WebNavigationResult.Success && !string.IsNullOrEmpty(e.Url))
            {
                PrimaryButton.Text = "Back To Home";
                // Do something with the query string values here...
            }
        }
    }
}