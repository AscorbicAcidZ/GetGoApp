using GetGoApp.Class;
using GetGoApp.Views.Home;
using GetGoApp.Views.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetGoApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : ContentPage
	{
        private string link, Details, userId;
        public Menu ()
		{
			InitializeComponent ();
            Details = AppData.Instance.Details;
            InitializeContent();
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
        private void WebView(string link, string input) => webView.Source = new UrlWebViewSource { Url = $"{link}/Views/UserApp/Menu/Menu.aspx?{input}" };
        private void HomeImage_Tapped(object sender, EventArgs e) => Navigation.PushAsync(new Home_Primary());
        private void Settings_Tapped(object sender, EventArgs e) => Navigation.PushAsync(new Settings());
        private void MenuImage_Tapped(object sender, EventArgs e) => Navigation.PushAsync(new Menu());
       
    }
}