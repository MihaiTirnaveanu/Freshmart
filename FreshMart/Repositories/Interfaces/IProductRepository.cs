using FreshMart.Models;

namespace FreshMart.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetByIdWithRelatedEntities(int id);

        Product GetById(int id);
        bool ProductExists(int id);
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);

        void Save();

        List<Category> GetAllCategories();
        List<Supplier> GetAllSuppliers();

        IEnumerable<Product> GetSearchProducts(string productname);

        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
    }
}
