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

        public void Delete(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
        }

        public CartItem GetById(int id)
        {
            return _context.CartItems.FirstOrDefault(c => c.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
