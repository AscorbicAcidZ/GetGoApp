using GetGoApp.Class;
using GetGoApp.Views.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetGoApp.Views.Forget
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePass : ContentPage
    {
        private string link, weblink;
        public ChangePass()
        {
            try
            {
                InitializeComponent();

                link = AppData.Instance.Link;
                //weblink = $"{link}/Views/UserApp/Signup/Change_Password.aspx";
                if (!string.IsNullOrEmpty(link))
                {
                    webView.Source = new UrlWebViewSource { Url = $"{link}/Views/UserApp/Signup/Change_Password.aspx" };
                    PrimaryButton.Text = "Proceed";
                }
                // Attach event handlers for WebView navigation
                //webView.Navigating += OnWebViewNavigating;
                //webView.Navigated += OnWebViewNavigated;

            }
            catch (Exception ex)
            {
                DisplayAlert("Access Failed", ex.ToString(), "OK");

            }

        }
        private async void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            // Check if the navigation was successful and the URL is not null or empty
            if (e.Result == WebNavigationResult.Success && !string.IsNullOrEmpty(e.Url))
            {      
                    await Navigation.PushAsync(new ChangePass_Confirmation());
                         
            }
            else
            {
                await DisplayAlert("Error", "Please Try Again!", "OK");
            }
        }

        private async void PrimaryButton_Clicked(object sender, EventArgs e)
        {

            await webView.EvaluateJavaScriptAsync("Save();");
            webView.Navigated += WebView_Navigated;
        }
    }
}
    