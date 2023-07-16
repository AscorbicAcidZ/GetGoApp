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
		public Menu ()
		{
			InitializeComponent ();
		}
        private void HomeButton_Clicked(object sender, EventArgs e)
        {

            var Name = "";
            Navigation.PushAsync(new Views.Home.Home_Primary());
        }
    
        private void MenuButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Menu());
        }
        private void Profile_Clicked(object sender, EventArgs e)
        {
            var Name = "";
            //Navigation.PushAsync(new Profile(Name));
        }
        private void Notifications_Clicked(object sender, EventArgs e)  
        {

            Navigation.PushAsync(new Views.Notifications());
        }
        private void LoanHistory_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.LoanHistory());
        }
    }
}