using DataAccessLayer;
using DataTransferObjects.Entities;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace WorkingWithData.Pages
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ShoppingItem> ShoppingItems { get; set; }
        private uint itemCount;

        //public List<ShoppingItem> ShoppingItemsList { get; set; }

        public MainPage()
        {
            InitializeComponent();

            InitializeItems();
            ContentListView.ItemsSource = ShoppingItems;
        }

        private void InitializeItems()
        {
            //Get the Items From the Database
            this.ShoppingItems = new ObservableCollection<ShoppingItem>(Database.Instance.GetItemsAsync().Result);
            itemCount = ShoppingItems.Count > 0 ? ShoppingItems.Max(x => x.ItemID) + 1 : 0;
        }

        private void AddNewItem(object sender, System.EventArgs e)
        {
            ShoppingItem toAdd = new ShoppingItem
            {
                ItemID = itemCount++
            };

            // Let's first Add the item to the database
            Database.Instance.UpdateItemData(toAdd).Wait();

            this.ShoppingItems.Add(toAdd);

        }

        private async void ContentListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ShoppingItem currentItem = (ShoppingItem)e.Item;
            // TO DO: Display message with the quantity and a question if you want to delete the item
            // If the item is not deleted display the page


            await App.NavigationMethod.PushAsync(new ItemDescription(currentItem));
        }

        protected override bool OnBackButtonPressed()
        {
            // TO DO: Log out the user
            return base.OnBackButtonPressed();
        }
    }

}