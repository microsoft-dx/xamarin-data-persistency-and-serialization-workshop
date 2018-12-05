using DataTransferObjects.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkingWithData.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDescription : ContentPage
    {
        private readonly ShoppingItem _currentItem;

        public string Name => _currentItem.ItemName;
        public string Description => _currentItem.ItemDescription;
        public uint Quantity => _currentItem.ItemQuantity;


        public ItemDescription(ShoppingItem itemToPresent)
        {
            InitializeComponent();
            _currentItem = itemToPresent;

            // TO DO: set Bindings or treat them for data saving
        }

        private async void GoBack(object sender, System.EventArgs e)
        {
            // TO DO: Update the item data acordingly

            await App.NavigationMethod.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            // TO DO: Do the same as above

            return base.OnBackButtonPressed();
        }
    }
}