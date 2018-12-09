using DataTransferObjects.Users;
using System;
using WorkingWithData.Utilities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkingWithData.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthenticationPage : ContentPage
    {
        public AuthenticationPage()
        {
            InitializeComponent();

            // if this is the first time the user runs the application ...
            if (Settings.FirstRunEver)
            {
                Settings.FirstRunEver = false;

                // display dialog informing user about authentication funcitonality
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Identity Check", "Please enter your username and password in order to use this app. If you do not have an account please click Register instead of Authenticate and we will handle it from there!", "OK");
                });
            }
        }

        private async void AuthenticateMethod(object sender, EventArgs e)
        {
            // TO DO: Authenticate with the Server USING Requests
            bool isUserAuthenticated = false;

            if (isUserAuthenticated)
            {
                // navigate to the application page
                await App.NavigationMethod.PushAsync(new MainPage());
            }
            else
            {
                // Also Update the Error Message Accordingly
                await DisplayAlert("Authentication Failed", "Invalid Username or Password", "OK");
            }
        }

        private async void RegisterMethod(object sender, EventArgs e)
        {
            try
            {
                // First we send a request to the server to the Register Controller with our
                // Desired username and password
                // We should move this in the register method of the authentication class
                string serializedUser = await WebRequests.GetAsync("Register",
                    new System.Collections.Generic.Dictionary<string, string>{
                    { "username", userName.Text },
                    { "password", passWord.Text }
                    });
                // Now we need to deserialize the userdata
                User currentUser = new User(serializedUser);

                // First we set the authenticated user because our DB connection relies on IT
                Settings.AuthenticatedUserID = currentUser.UserID;

                // Now we can move forward to the Main Page
                await DataAccessLayer.Database.Instance.AddAuthenticatedUser(currentUser);

                // navigate to the application page
                await App.NavigationMethod.PushAsync(new MainPage());
            }
            catch
            {
                // We may want to check that
                await DisplayAlert("Error", "There was an error, please try again!", "OK");
            }
        }
    }
}