using FreshMart.Models;

namespace FreshMart.Repositories.Interfaces
{
    public interface ICartItemRepository
    {
        void Create(CartItem cartItem);
    }
}
