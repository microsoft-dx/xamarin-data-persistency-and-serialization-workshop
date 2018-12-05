using System.Collections.Generic;

namespace DataTransferObjects.Entities
{
    public class ShoppingItem
    {
        public uint ItemID { get; set; }
        public uint ItemQuantity { get; set; }

        public string ItemName { get; set; }
        public string ItemDescription { get; set; }

        public override string ToString()
        {
            return this.ItemName;
        }

        public override bool Equals(object obj)
        {
            var item = obj as ShoppingItem;

            return item.ItemName == this.ItemName;
        }

        public override int GetHashCode()
        {
            var hashCode = -1919740922;
            hashCode = hashCode * -1521134295 + ItemID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ItemName);
            return hashCode;
        }

        public ShoppingItem() { }
    }
}
