using FreshMart.Models;
using FreshMart.Repositories.Interfaces;
using FreshMart.Services.Interfaces;

namespace FreshMart.Services
{
    public class SupplierService : ISupplierService
    {
        private ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public void AddSupplier(Supplier supplier)
        {
            _supplierRepository.Create(supplier);
            _supplierRepository.Save();
        }

        public void DeleteSupplier(int id)
        {
            var supplier = _supplierRepository.GetById(id);
            if (supplier != null)
            {
                _supplierRepository.Delete(supplier);
                _supplierRepository.Save();
            }
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _supplierRepository.GetAll().ToList();
        }

        public Supplier GetSupplierById(int id)
        {
            return _supplierRepository.GetById(id);
        }

        public bool SupplierExists(int id)
        {
            return _supplierRepository.SupplierExists(id);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            _supplierRepository.Update(supplier);
            _supplierRepository.Save();
        }
    }
}
