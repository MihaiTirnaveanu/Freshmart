using FreshMart.Models;

namespace FreshMart.Repositories.Interfaces
{
    public interface ICartItemRepository
    {
        void Create(CartItem cartItem);

        void Delete(CartItem cartItem);

        CartItem GetById(int id);

        void Save();
    }
}
