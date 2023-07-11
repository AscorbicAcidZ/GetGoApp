using GetGoApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;

namespace GetGoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }



        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            // Create the URL with the query string parameters
            string url = "https://longsparklydart32.conveyor.cloud/Views/UserApp/AuthenticateUser.aspx?UserName=" + usernameEntry.Text + "&Password=" + passwordEntry.Text;

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

                    // Parse the query string
                    string queryString = response.RequestMessage.RequestUri.Query;
                    string Name = HttpUtility.ParseQueryString(queryString)["Name"];

                    if (!string.IsNullOrEmpty(Name))
                    {
                        // Navigate to another page
                        await Navigation.PushAsync(new Views.Home(Name));
                    }
                    else
                    {
                        await DisplayAlert("Login Failed", "Invalid username or password", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and display an error message
                await DisplayAlert("Error", ex.Message, "OK");
            }

        }
        private async void SignUpLabel_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration());
        }
    }
}


