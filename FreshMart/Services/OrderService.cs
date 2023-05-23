using FreshMart.Models;
using FreshMart.Repositories;
using FreshMart.Repositories.Interfaces;
using FreshMart.Services.Interfaces;

namespace FreshMart.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void AddOrder(Order order)
        {
            _orderRepository.Create(order);
            _orderRepository.Save();
        }

        public void DeleteOrder(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order != null)
            {
                _orderRepository.Delete(order);
                _orderRepository.Save();
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return _orderRepository.GetAllCustomers();
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAll().ToList();
        }

        public List<ShoppingCart> GetAllShoppingCarts()
        {
            return _orderRepository.GetAllShoppingCarts();
        }

        public Order GetOrderAndRelatedById(int id)
        {
            return _orderRepository.GetByIdWithRelatedEntities(id);
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public bool OrderExists(int id)
        {
           return _orderRepository.OrderExists(id);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
            _orderRepository.Save();
        }
    }
}
