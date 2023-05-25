using FreshMart.Data;
using FreshMart.Models;
using FreshMart.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FreshMart.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private SupermarketContext _context;
        public ProductRepository(SupermarketContext context)
        {
            _context = context;

        }
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(p => p.Category).Include(p => p.Supplier).ToList();
        }

        public Product GetByIdWithRelatedEntities(int id)
        {
            return _context.Products.Include(p => p.Category).Include(p => p.Supplier).FirstOrDefault(p => p.Id == id);
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(c => c.Id == id);
        }



        public void Create(Product product)
        {
            _context.Products.Add(product);
        }

        public void Delete(Product product)
        {
            _context.Remove(product);
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
        public List<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetSearchProducts(string productname)
        {
            return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => p.Name == productname).ToList();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
