using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkingWithData.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AuthenticationPage : ContentPage
	{
		public AuthenticationPage ()
		{
			InitializeComponent ();
		}

        private async void AuthenticateMethod(object sender, EventArgs e)
        {
            // TO DO: Authenticate with the Server USING Requests
            bool isUserAuthenticated = false;

            if (isUserAuthenticated)
            {
                await App.NavigationMethod.PushAsync(new MainPage());
            }
            else
            {
                // Also Update the Error Message Acordingly
                await DisplayAlert("Authentication Failed", "Invalid Username or Password", "OK");
            }
        }
    }
}