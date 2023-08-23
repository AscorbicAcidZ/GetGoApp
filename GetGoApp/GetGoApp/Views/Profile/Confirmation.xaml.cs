using GetGoApp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetGoApp.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Confirmation : ContentPage
    {
        private string link, signupDetails, Details;
        public Confirmation()
        {
            InitializeComponent();
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            link = AppData.Instance.Link;
            signupDetails = AppData.Instance.SignupDetails;
        
            await Navigation.PushAsync(new Home.Home_Primary());
        }
    }
}