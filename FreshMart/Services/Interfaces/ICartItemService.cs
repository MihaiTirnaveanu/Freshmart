using FreshMart.Models;

namespace FreshMart.Services.Interfaces
{
    public interface ICartItemService
    {
        void AddCartItem(CartItem cartItem);

        void DeleteCartItem(CartItem cartItem);

        CartItem GetCartItemById(int id);
    }
}
