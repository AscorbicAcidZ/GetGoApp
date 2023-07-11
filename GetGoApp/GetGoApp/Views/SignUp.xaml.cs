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
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
            webView.Source = new UrlWebViewSource { Url = "https://longsparklydart32.conveyor.cloud/Views/UserApp/SignUp.aspx" };
        }
        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            webView.EvaluateJavaScriptAsync("saveData();");
        }


    }
}