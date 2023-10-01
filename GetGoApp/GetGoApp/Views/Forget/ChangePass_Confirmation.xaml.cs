using GetGoApp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetGoApp.Views.Forget
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
 
    public partial class ChangePass_Confirmation : ContentPage

    {
        private string link;
        public ChangePass_Confirmation()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            link = AppData.Instance.Link;
            await Navigation.PushAsync(new Login());
        }
    }
}