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
    public partial class Home : ContentPage
    {
        public Home(string Name)
        {
            InitializeComponent();
            webView.Source = new UrlWebViewSource { Url = "https://longsparklydart32.conveyor.cloud/Views/UserApp/Home.aspx" };
        }
        private void HomeButton_Clicked(object sender, EventArgs e)
        {
            var Name = "";
            Navigation.PushAsync(new Views.Home(Name));
        }

        private void MenuButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Menu());
        }
    }
}