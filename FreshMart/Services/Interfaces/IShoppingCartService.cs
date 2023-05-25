using FreshMart.Models;

namespace FreshMart.Services.Interfaces
{
    public interface IShoppingCartService
    {
        List<ShoppingCart> GetAllShoppingCarts();
        ShoppingCart GetShoppingCartById(int id);
        bool ShoppingCartExists(int id);
        void AddShoppingCart(ShoppingCart shoppingCart);
        void UpdateShoppingCart(ShoppingCart shoppingCart);
        void DeleteShoppingCart(int id);
        ShoppingCart GetExistingShoppingCart();

        void AddCartItem(ShoppingCart shoppingCart, CartItem cartItem);

        void LoadCartCollection(ShoppingCart shoppingCart);

        void removeCartItem(ShoppingCart shoppingCart, CartItem cartItem);
    }
}
