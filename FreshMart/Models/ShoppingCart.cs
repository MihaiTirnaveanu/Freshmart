using Microsoft.AspNetCore.Identity;

namespace FreshMart.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public double Amount { get; set; }

        public Order? Order { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public string UserId { get; set; }

        public IdentityUser User { get; set; }
        public ShoppingCart()
        {
            CartItems = new List<CartItem>();
        }

        public void AddItem(Product product, int quantity)
        {
            // Check if the item is already in the cart
            var existingItem = CartItems.FirstOrDefault(item => item.ProductId == product.Id);

            if (existingItem != null)
            {
                // Item already exists, update the quantity
                existingItem.Quantity += quantity;
            }
            else
            {
                // Item doesn't exist, add it to the cart
                var newItem = new CartItem
                {
                    Product = product,
                    Quantity = quantity
                };
                CartItems.Add(newItem);
            }
        }

        public void RemoveItem(Product product)
        {
            var itemToRemove = CartItems.FirstOrDefault(item => item.ProductId == product.Id);
            if (itemToRemove != null)
            {
                CartItems.Remove(itemToRemove);
            }
        }

        public double CalculateTotalPrice()
        {
            return CartItems.Sum(item => item.TotalPrice);
        }
    }
}
