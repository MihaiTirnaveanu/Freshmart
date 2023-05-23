using FreshMart.Models;

namespace FreshMart.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        bool CustomerExists(int id);
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        void Save();
    }
}
