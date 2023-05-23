using FreshMart.Models;
using FreshMart.Repositories.Interfaces;
using FreshMart.Services.Interfaces;

namespace FreshMart.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll().ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public bool CustomerExists(int id)
        {
            return _customerRepository.CustomerExists(id);
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.Create(customer);
            _customerRepository.Save();
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
            _customerRepository.Save();
        }

        public void DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer != null) {
                _customerRepository.Delete(customer);
                _customerRepository.Save();
            }
        }
    }
}
