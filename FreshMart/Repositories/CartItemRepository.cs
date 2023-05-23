using FreshMart.Data;
using FreshMart.Models;
using FreshMart.Repositories.Interfaces;

namespace FreshMart.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private SupermarketContext _context;

        public CartItemRepository(SupermarketContext context)
        {
            _context = context;
        }
        public void Create(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
        }
    }
}
