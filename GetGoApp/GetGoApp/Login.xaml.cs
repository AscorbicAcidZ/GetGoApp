using GetGoApp.Class;
using GetGoApp.Views;
using GetGoApp.Views.Signup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetGoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private string link;
        public Login()
        {
            InitializeComponent();

           link = AppData.Instance.Link;
        }
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            loadingLayout.IsVisible = true;
            // Create the URL with the query string parameters
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            // Construct the URL based on the link and parameters
            string url = BuildUrl(link, username, password);

            try
            {
                // Send the HTTP request
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Error", "Failed to connect to the server", "OK");
                        loadingLayout.IsVisible = false;
                        return;
                    }

                    response.EnsureSuccessStatusCode();

                    string responseContent = await response.Content.ReadAsStringAsync();

                    // Check if the response content contains "Wrong pass"
                    if (responseContent.Contains("46FFE43A74AC2CAF593E9DCEAB229"))
                    {
                        await DisplayAlert("Login Failed", "Invalid username or password.", "OK");
                        usernameEntry.Text = "";
                        passwordEntry.Text = "";
                        usernameEntry.Focus();

                        loadingLayout.IsVisible = false;
                        return;
                    }
                    // Parse the query string
                    string queryString = response.RequestMessage.RequestUri.Query;
                    Dictionary<string, string> queryParameters = HttpUtility.ParseQueryString(queryString)
                        .AllKeys.ToDictionary(key => key, key => HttpUtility.ParseQueryString(queryString)[key]);

                    // Build the details string
                    string details = BuildDetailsString(link, queryParameters);

                    // Set the details value in the global data storage class
                    AppData.Instance.Details = details;

                    // Navigate to the Home_Primary page
                    await Navigation.PushAsync(new Views.Home.Home_Primary());
                    loadingLayout.IsVisible = false;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and display an error message
                await DisplayAlert("Error", ex.Message, "OK");
                loadingLayout.IsVisible = false;
            }
        }

        private string BuildUrl(string link, string username, string password)
        {
            string url = "";

            if (link.Contains("http://"))
            {
                url = $"{link}/Views/UserApp/AuthenticateUser.aspx?UserName={username}&Password={password}";
            }
            else
            {
                url = $"{link}Views/UserApp/AuthenticateUser.aspx?UserName={username}&Password={password}";
            }

            return url;
        }

        private string BuildDetailsString(string link, Dictionary<string, string> queryParameters)
        {
            StringBuilder details = new StringBuilder();
            details.Append($"{link}|");
            foreach (var parameter in queryParameters)
            {
                details.Append($"{parameter.Key}:{parameter.Value}|");
            }
            return details.ToString();
        }
        private async void SignUpLabel_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Signup_Primary());
        }
    }
}