using FreshMart.Data;
using FreshMart.Models;
using FreshMart.Repositories.Interfaces;

namespace FreshMart.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private SupermarketContext _context;

        public CustomerRepository(SupermarketContext context)
        {
            _context = context;
        }

        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public bool CustomerExists(int id)
        {
            return _context.Customers.Any(c => c.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void Save(int id)
        {
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Remove(customer);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
