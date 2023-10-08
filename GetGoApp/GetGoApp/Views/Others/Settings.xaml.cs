using GetGoApp.Class;
using GetGoApp.Views.Signup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetGoApp.Views.Others
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            AppData.Instance.Details = null;
            AppData.Instance.UserId = null;
            AppData.Instance.UserToken = null;
            AppData.Instance.SignupDetails = null;
            await Navigation.PushAsync(new Start());
            Navigation.RemovePage(this);
        }
        protected override bool OnBackButtonPressed()
        {
            // Prevent navigating back to the Settings page
            return true;
        }

        private  async void AboutUs_Clicked(object sender, EventArgs e) =>  await Navigation.PushAsync(new Others.AboutUs());

        private async void Forgot_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new Forgot_Password());
      
    }
}