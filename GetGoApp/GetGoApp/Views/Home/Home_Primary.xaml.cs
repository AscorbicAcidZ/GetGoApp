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
        private string link, name;
      
        public Home_Primary()
        {
          
            InitializeComponent();

            string details = AppData.Instance.Details;
            if (!string.IsNullOrEmpty(details))
            {
                string[] detailsArray = details.Split('|');
                if (detailsArray.Length >= 2)
                {
                    link = detailsArray[0];
                    name = detailsArray[1];
                }
            }
            webView.Source = new UrlWebViewSource { Url = $"{link}/Views/UserApp/Profile/Profile_Primary.aspx" };
        }
        private void HomeButton_Clicked(object sender, EventArgs e)
        {
        
            Navigation.PushAsync(new Views.Home.Home_Primary());
        }

        private void MenuButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Menu());
        }
    }
}