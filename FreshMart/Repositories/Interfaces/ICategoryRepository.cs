using FreshMart.Models;

namespace FreshMart.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);

        bool CategoryExists(int id);
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);

        void Save();
    }
}
