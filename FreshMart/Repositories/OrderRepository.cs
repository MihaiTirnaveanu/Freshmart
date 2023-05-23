using FreshMart.Data;
using FreshMart.Models;
using FreshMart.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FreshMart.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private SupermarketContext _context;

        public OrderRepository(SupermarketContext context)
        {
            _context = context;
        }

        public void Create(Order order)
        {
            _context.Orders.Add(order);
        }

        public void Delete(Order order)
        {
            _context.Remove(order);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.Include(o => o.Customer).Include(o => o.ShoppingCart);
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public List<ShoppingCart> GetAllShoppingCarts()
        {
            return _context.ShoppingCarts.ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders.Find(id);
        }

        public Order GetByIdWithRelatedEntities(int id)
        {
            return _context.Orders.Include(o => o.Customer).Include(o => o.ShoppingCart).FirstOrDefault(o => o.Id == id);
        }

        public bool OrderExists(int id)
        {
            return _context.Orders.Any(o => o.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Update(order);
        }
    }
}
