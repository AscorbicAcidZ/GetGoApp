using GetGoApp.Class;
using GetGoApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetGoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Start : ContentPage
    {
        public Start()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string link = linkEntry.Text; // Get the link from the entry box

            AppData.Instance.Link = link;

            await Navigation.PushAsync(new Login());
         
        }
    }
}