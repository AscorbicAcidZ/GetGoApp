using GetGoApp.Class;
using GetGoApp.Views.Home;
using GetGoApp.Views.Others;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetGoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            string details = SecureStorage.GetAsync("userLink").Result;
            if (details != null)
            {
                AppData.Instance.Link = details;
                MainPage = new NavigationPage(new Login());
            }
            else
            {
                MainPage = new NavigationPage(new Start());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
