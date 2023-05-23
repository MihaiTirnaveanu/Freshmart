using FreshMart.Models;
using FreshMart.Repositories;
using FreshMart.Repositories.Interfaces;
using FreshMart.Services.Interfaces;

namespace FreshMart.Services
{
    public class CartItemService : ICartItemService
    {
        private ICartItemRepository _repository;

        public CartItemService(ICartItemRepository repository)
        {
            _repository = repository;
        }

        public void AddCartItem(CartItem cartItem)
        {
            _repository.Create(cartItem);
        }
    }
}
