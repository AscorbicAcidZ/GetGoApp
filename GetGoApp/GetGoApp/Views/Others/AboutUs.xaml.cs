using GetGoApp.Class;
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
    public partial class AboutUs : ContentPage
    {
        private string link;
        public AboutUs()
        {
            InitializeComponent();
            link = AppData.Instance.Link;

            if (!string.IsNullOrEmpty(link))
            {
                webView.Source = new UrlWebViewSource { Url = $"{link}/Views/UserApp/Menu/AboutUs.aspx" };
            }
        }
    }
}