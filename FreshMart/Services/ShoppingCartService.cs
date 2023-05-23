using FreshMart.Models;
using FreshMart.Repositories;
using FreshMart.Repositories.Interfaces;
using FreshMart.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FreshMart.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private IShoppingCartRepository _shoppingCartRepository;
        private IUserService _userService;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IUserService userService)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _userService = userService;
        }

        public void AddShoppingCart(ShoppingCart shoppingCart)
        {
            _shoppingCartRepository.Create(shoppingCart);
            _shoppingCartRepository.Save();
        }

        public void DeleteShoppingCart(int id)
        {
            var shoppingCart = _shoppingCartRepository.GetById(id);
            if (shoppingCart != null)
            {
                _shoppingCartRepository.Delete(shoppingCart);
                _shoppingCartRepository.Save();
            }
        }

        public List<ShoppingCart> GetAllShoppingCarts()
        {
            return _shoppingCartRepository.GetAll().ToList();
        }

        public ShoppingCart GetShoppingCartById(int id)
        {
            return _shoppingCartRepository.GetById(id);
        }

        public bool ShoppingCartExists(int id)
        {
            return _shoppingCartRepository.ShoppingCartExists(id);
        }

        public void UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            _shoppingCartRepository.Update(shoppingCart);
            _shoppingCartRepository.Save();
        }

        public ShoppingCart GetExistingShoppingCart()
        {
            var user = _userService.GetCurrentLoggedInUser();

            var shoppingCart = _shoppingCartRepository.GetByUserId(user.Id);

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart
                {
                    UserId = user.Id,
                    User = user,
                    Amount = 0,
                    Size = 0
                };

                AddShoppingCart(shoppingCart);
            }

            return shoppingCart;
        }

        public void AddCartItem(ShoppingCart shoppingCart, CartItem cartItem)
        {
            CartItem existingCartItem = shoppingCart.CartItems.FirstOrDefault(ci => ci.ProductId == cartItem.ProductId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += cartItem.Quantity;
            }
            else
            {
                shoppingCart.CartItems.Add(cartItem);
            }

            shoppingCart.Size = shoppingCart.CartItems.Sum(ci => ci.Quantity);
            shoppingCart.Amount = shoppingCart.CartItems.Sum(ci => ci.Quantity * ci.Product.Price);

            UpdateShoppingCart(shoppingCart);
        }

    }
}
