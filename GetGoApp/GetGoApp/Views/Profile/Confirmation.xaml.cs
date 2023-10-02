using GetGoApp.Class;
using GetGoApp.Views.Home;
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
        private string link, signupDetails;
        public Confirmation()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            try
            {
                await Navigation.PushAsync(new Login());
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}