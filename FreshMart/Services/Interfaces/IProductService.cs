using FreshMart.Models;

namespace FreshMart.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductAndRelatedById(int id);
        bool ProductExists(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);

        List<Category>GetAllCategories();
        List<Supplier> GetAllSuppliers();

        Product GetProductById(int id);

        List<Product> GetSearchedProducts(string productName);

        List<Product> GetProductsByCategoryId(int categoryId);
    }
}
