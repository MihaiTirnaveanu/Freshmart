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
    }
}
