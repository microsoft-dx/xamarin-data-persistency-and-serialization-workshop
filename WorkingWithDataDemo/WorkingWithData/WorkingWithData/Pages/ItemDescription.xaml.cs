using DataAccessLayer;
using DataTransferObjects.Entities;
using System.Threading.Tasks;
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

            ItemNameEntry.Text = _currentItem.ItemName;
            ItemDescriptionEntry.Text = _currentItem.ItemDescription;

            // TO DO: set Bindings or treat them for data saving
            ItemQtyStepper.Minimum = 0;
            ItemQtyStepper.Maximum = 50;
            ItemQtyStepper.Increment = 1;
            ItemQtyStepper.Value = _currentItem.ItemQuantity;

            ItemQty.Text = ItemQtyStepper.Value.ToString();
            ItemQtyStepper.ValueChanged += (s, e) => { ItemQty.Text = ItemQtyStepper.Value.ToString(); };
        }

        private async void GoBack(object sender, System.EventArgs e)
        {
            // TO DO: Update the item data acordingly

            GoBackToMainPage();
        }

        private async void GoBackToMainPage() {
            
            _currentItem.ItemName = ItemNameEntry.Text;
            _currentItem.ItemDescription = ItemDescriptionEntry.Text;
            _currentItem.ItemQuantity = (uint)ItemQtyStepper.Value;

            await Database.Instance.UpdateItemData(_currentItem);

            await App.NavigationMethod.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            // TO DO: Do the same as above
            GoBackToMainPage();

            return true;
        }
    }
}