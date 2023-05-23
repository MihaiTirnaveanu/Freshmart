using FreshMart.Models;

namespace FreshMart.Services.Interfaces
{
    public interface ISupplierService
    {
        List<Supplier> GetAllSuppliers();
        Supplier GetSupplierById(int id);
        bool SupplierExists(int id);
        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(int id);
    }
}
