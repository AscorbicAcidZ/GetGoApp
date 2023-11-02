using GetGoApp.Class;
using GetGoApp.Views;
using GetGoApp.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            //testing the secureStorage test is working 
            // what to do next to do the biometrics 
            if (string.IsNullOrEmpty(linkEntry.Text))
            {
                string details = SecureStorage.GetAsync("userLink").Result;
                if (details != "default")
                {
                    AppData.Instance.Link = details;
                    await Navigation.PushAsync(new Login());
                }
                else
                {
                    await DisplayAlert("Information", "Please input the url", "Confirm");
                }
            }
            else
            {
                string NewLink = linkEntry.Text.Trim();
                BuildUrl(NewLink);
            }
            // Now you can use the storedLink variable as needed

            //AppData.Instance.Link = link;

            //await Navigation.PushAsync(new Login());

        }
        private async void BuildUrl(string rawUrl)
        {
            var newUrl = "";
            var url = "";
            if (!rawUrl.Contains("http://"))
            {
                newUrl = "http://" + rawUrl + "/GetGo";
                url = $"{newUrl}/Views/Auth/Default.aspx?ACTION=AuthLink";
            }
            else
            {
                url = $"{rawUrl}/Views/Auth/Default.aspx?ACTION=AuthLink";
            }


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

                    // Check if the response content contains "Wrong pass"
                    if (responseContent.Contains("46FFE43A74AC2CAF593E9DCEAB229"))
                    {
                        if (!rawUrl.Contains("http://"))
                        {
                            newUrl = "http://" + rawUrl + "/GetGo";
                            url = $"{newUrl}/Views/Auth/Default.aspx";

                            await SecureStorage.SetAsync("userLink", newUrl);
                            AppData.Instance.Link = newUrl;
                            await Navigation.PushAsync(new Login());
                        }
                        else
                        {
                            string details = SecureStorage.GetAsync("userLink").Result;
                            AppData.Instance.Link = details;
                            await Navigation.PushAsync(new Login());
                        }

                    }
                    else
                    {
                        await DisplayAlert("a", "Something Went Wrong", "OK");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void linkEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string validCharactersPattern = @"[^0-9\.]"; // Regular expression pattern allowing only numbers and a dot

            string newText = System.Text.RegularExpressions.Regex.Replace(e.NewTextValue, validCharactersPattern, "");
            if (newText != e.NewTextValue)
            {
                linkEntry.Text = newText;
            }
        }
    }
}