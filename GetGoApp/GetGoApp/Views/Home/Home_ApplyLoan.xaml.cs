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
    public partial class Home_ApplyLoan : ContentPage
    {
        public Home_ApplyLoan()
        {
            InitializeComponent();
            webView.Source = new UrlWebViewSource
            {
                Url = $"http://192.168.1.8/GetGo/Views/UserApp/Home/ApplyLoan.aspx?USERID=APP230924001"
            };
        }

        private void PrimaryButton_Clicked(object sender, EventArgs e)
        {
            webView.EvaluateJavaScriptAsync("Save();");
        }
    }
}