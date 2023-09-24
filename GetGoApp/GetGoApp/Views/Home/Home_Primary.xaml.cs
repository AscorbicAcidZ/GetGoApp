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
    public partial class Home_Primary : ContentPage
    {
        private string link, signupDetails, Details, userId;

        public Home_Primary()
        {
            InitializeComponent();
            webView.Source = new UrlWebViewSource
            {
                Url = $"http://192.168.1.19/GetGo/Views/UserApp/Home/Home_Default.aspx?USERID=APP230819017"
            };
            //InitializeContent();  
        }

        private void InitializeContent()
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

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void WebView(string link, string input) => webView.Source = new UrlWebViewSource { Url = $"{link}/Views/UserApp/Home/Home_Default.aspx?{input}" };
        private void HomeImage_Tapped(object sender, EventArgs e) => Navigation.PushAsync(new Home_Primary());

        private void MenuImage_Tapped(object sender, EventArgs e) => Navigation.PushAsync(new Menu());

        //private void HomeButton_Clicked(object sender, EventArgs e)
        //{

        //    Navigation.PushAsync(new Views.Home.Home_Primary());
        //}

        //private void MenuButton_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new Views.Menu());
        //}
    }
}