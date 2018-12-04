namespace WorkingWithData.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new WorkingWithData.App());
        }
    }
}
