using FreshMart.Models;

namespace FreshMart.Repositories.Interfaces
{
    public interface IOrderRepository 
    {
        IEnumerable<Order> GetAll();
        Order GetByIdWithRelatedEntities(int id);

        Order GetById(int id);
        bool OrderExists(int id);
        void Create(Order order);
        void Update(Order order);
        void Delete(Order order);

        void Save();

        List<Customer> GetAllCustomers();
        List<ShoppingCart> GetAllShoppingCarts();
    }
}
