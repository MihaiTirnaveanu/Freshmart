using FreshMart.Models;

namespace FreshMart.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        IEnumerable<ShoppingCart> GetAll();
        ShoppingCart GetById(int id);

        bool ShoppingCartExists(int id);
        void Create(ShoppingCart shoppingCart);
        void Update(ShoppingCart shoppingCart);
        void Delete(ShoppingCart shoppingCart);

        void Save();

        ShoppingCart GetByUserId(string userId);

        void LoadCartCollection(ShoppingCart shoppingCart);


    }
}
