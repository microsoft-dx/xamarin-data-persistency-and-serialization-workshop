using DataAccessLayer.Entities;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkingWithData.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDescription : ContentPage
    {
        public ItemDescription(ShoppingItem itemToPresent)
        {
            InitializeComponent();

            ItemStack.Children.Add(new Label { Text = $"My id is {itemToPresent.ItemId: 00}" });
            ItemStack.Children.Add(new Label { Text = $"My description is {itemToPresent.ItemName}" });
            if (Utilities.Settings.AuthenticatedUserID == 0)
            {
                Utilities.Settings.AuthenticatedUserID = 5;
            }
            else
            {
                Utilities.Settings.AuthenticatedUserID = Utilities.Settings.AuthenticatedUserID + 1;
            }
            ItemStack.Children.Add(new Label { Text = $"Zi ID is {Utilities.Settings.AuthenticatedUserID}" });
        }

        private async void GoBack(object sender, System.EventArgs e)
        {
            await App.NavigationMethod.PopAsync();
        }
    }
}