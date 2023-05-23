using FreshMart.Models;
using FreshMart.Repositories.Interfaces;
using FreshMart.Services.Interfaces;

namespace FreshMart.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll().ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public bool CategoryExists(int id)
        {
            return _categoryRepository.CategoryExists(id);
        }

        public void AddCategory(Category category)
        {
            _categoryRepository.Create(category);
            _categoryRepository.Save();
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
            _categoryRepository.Save();
        }

        public void DeleteCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category != null)
            {
                _categoryRepository.Delete(category);
                _categoryRepository.Save();
            }
        }
    }
}
