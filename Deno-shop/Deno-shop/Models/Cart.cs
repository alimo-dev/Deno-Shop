using System.Collections.Generic;
using System.Linq;

namespace Deno_shop.Models
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public int OrderID { get; set; }
        public List<CartItem> CartItems { get; set; }

        public void AddItem(CartItem item)
        {
            if (CartItems.Exists(i => i.Item.Id == item.Id))
            {
                CartItems.Find(i => i.Item.Id == item.Item.Id).Quantity += 1;
            }
            else
            {
                CartItems.Add(item);
            }
        }

        public void RemoveItem(int itemId)
        {
            var item = CartItems.SingleOrDefault(i => i.Item.Id == itemId);
            if (item?.Quantity <= 1)
            {
                CartItems.Remove(item);
            }
            else if(item != null)
            {
                item.Quantity -= 1;
            }
        }
    }
}
