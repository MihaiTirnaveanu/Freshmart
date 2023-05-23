using FreshMart.Models;

namespace FreshMart.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        bool CategoryExists(int id);
        void AddCategory(Category category);
        void  UpdateCategory(Category category);
        void  DeleteCategory(int id);
    }
}
