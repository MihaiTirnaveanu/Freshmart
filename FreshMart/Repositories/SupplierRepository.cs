using FreshMart.Data;
using FreshMart.Models;
using FreshMart.Repositories.Interfaces;

namespace FreshMart.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private SupermarketContext _context;
        public SupplierRepository(SupermarketContext context)
        {
            _context = context;

        }
        public IEnumerable<Supplier> GetAll()
        {
            return _context.Suppliers.ToList();
        }

        public Supplier GetById(int id)
        {
            return _context.Suppliers.FirstOrDefault(c => c.Id == id);
        }

        public bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(c => c.Id == id);
        }

        public void Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
        }

        public void Delete(Supplier supplier)
        {
            _context.Remove(supplier);
        }

        public void Update(Supplier supplier)
        {
            _context.Update(supplier);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
