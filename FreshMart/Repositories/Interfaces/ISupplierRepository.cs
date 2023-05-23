using FreshMart.Models;

namespace FreshMart.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);

        bool SupplierExists(int id);
        void Create(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(Supplier supplier);

        void Save();
    }
}
