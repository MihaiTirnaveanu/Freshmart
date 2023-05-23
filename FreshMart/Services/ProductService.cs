using FreshMart.Models;
using FreshMart.Repositories;
using FreshMart.Repositories.Interfaces;
using FreshMart.Services.Interfaces;
using NuGet.Protocol.Core.Types;

namespace FreshMart.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public Product GetProductAndRelatedById(int id)
        {
            return _productRepository.GetByIdWithRelatedEntities(id);
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public bool ProductExists(int id)
        {
            return _productRepository.ProductExists(id);
        }

        public List<Category> GetAllCategories()
        {
            return _productRepository.GetAllCategories();
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _productRepository.GetAllSuppliers();
        }

        public void AddProduct(Product product)
        {
            _productRepository.Create(product);
            _productRepository.Save();
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            _productRepository.Save();
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product != null)
            {
                _productRepository.Delete(product);
                _productRepository.Save();
            }
        }
    }
}
