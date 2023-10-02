using GetGoApp.Class;
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
    public partial class Home_Withdrawal : ContentPage
    {
        private string link, Details, userId;
        public Home_Withdrawal()
        {
            InitializeComponent();
            Initialize();
            InitializeContent();
        }
        private void Initialize()
        {
            Details = AppData.Instance.Details;

            // Your initialization logic here...
        }

        private void InitializeContent()
        {

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
            else
            {
                DisplayAlert("URL GOT LOST", "ERROR", "OK");
            }

        }
        private void WebView(string link, string input) => webView.Source = new UrlWebViewSource { Url = $"{link}/Views/UserApp/Home/Home_Withdrawal.aspx?{input}" };
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
                PrimaryButton.Text = "Confirm";
                // Do something with the query string values here...
            }
        }
    }

}