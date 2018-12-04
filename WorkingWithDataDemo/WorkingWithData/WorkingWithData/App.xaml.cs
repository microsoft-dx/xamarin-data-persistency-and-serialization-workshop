using WorkingWithData.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WorkingWithData
{
    public partial class App : Application
    {
        // Due to UWP being UWP, we need a navigation page
        public static readonly NavigationPage NavigationMethod = new NavigationPage();

        public App()
        {
            InitializeComponent();

            NavigationMethod.PushAsync(new AuthenticationPage());

            MainPage = NavigationMethod;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
