using GetGoApp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetGoApp.Views.Others
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Fingerprint : ContentPage
    {
        private string link, Details, userId;
        public Fingerprint()
        {
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            Details = AppData.Instance.Details;

            if (!string.IsNullOrEmpty(Details))
            {
                string[] detailsArray = Details.Split('|');
                if (detailsArray.Length >= 2)
                {
                    link = detailsArray[0];
                    userId = detailsArray[1].Replace(":", "=");

                }
            }
            else
            {
                return;
            }
     
         
            string token = SecureStorage.GetAsync("biometricsToken").Result;

            if (string.IsNullOrEmpty(token) || token == "default" || userId !=token)
            {
                    Disable.IsVisible = false;
                    Enable.IsVisible = true; 
            }
            else
            {
               
                Disable.IsVisible = true;
                Enable.IsVisible = false;
            }
            // Your initialization logic here...
        }


        private async void Enable_Clicked(object sender, EventArgs e)
        {

            await SecureStorage.SetAsync("biometricsToken", userId);
            Disable.IsVisible = true;
            Enable.IsVisible = false;
            await DisplayAlert("Information", "Fingerprint added successfully", "Confirm");

            //if (!string.IsNullOrEmpty(Details))
            //{
            //    string[] detailsArray = Details.Split('|');
            //    if (detailsArray.Length >= 2)
            //    {
            //        link = detailsArray[0];
            //        userId = detailsArray[1].Replace(":", "=");

            //        var url = $"{link}/Views/Auth/Default.aspx?ACTION=EnableBiometrics&USERID={userId}";
            //        EnableFingerPrint(url);
            //    }
            //}
            //else
            //{
            //    DisplayAlert("URL GOT LOST", "ERROR", "OK");
            //}
        }

        private async void Disable_Clicked(object sender, EventArgs e)
        {
            await SecureStorage.SetAsync("biometricsToken", "default");
            await DisplayAlert("Information", "fingerprint disabled please login again..", "Confirm");
            Disable.IsVisible = false;
            Enable.IsVisible = true;
            AppData.Instance.Details = null;
            AppData.Instance.UserId = null;

            AppData.Instance.SignupDetails = null;
            await Navigation.PushAsync(new Login());
            Navigation.RemovePage(this);
        }
        private async void EnableFingerPrint(string url)
        {
            try
            {
                // Send the HTTP request
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Error", "Failed to connect to the server", "OK");

                        return;
                    }

                    response.EnsureSuccessStatusCode();

                    string responseContent = await response.Content.ReadAsStringAsync();


                    // Parse the query string
                    string queryString = response.RequestMessage.RequestUri.Query;

                    await DisplayAlert("sucess", "yes", "ok");

                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and display an error message
                await DisplayAlert("Error", ex.Message, "OK");

            }
        }
    }
}
