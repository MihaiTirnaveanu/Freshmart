using FreshMart.Models;

namespace FreshMart.Services.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderAndRelatedById(int id);
        bool OrderExists(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);

        List<Customer> GetAllCustomers();
        List<ShoppingCart> GetAllShoppingCarts();

        Order GetOrderById(int id);
    }
}
