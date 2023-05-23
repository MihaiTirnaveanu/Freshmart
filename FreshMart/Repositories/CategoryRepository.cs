using FreshMart.Data;
using FreshMart.Models;
using FreshMart.Repositories.Interfaces;

namespace FreshMart.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private SupermarketContext _context;
        public CategoryRepository(SupermarketContext context) {
            _context = context;

        }
        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Delete(Category category)
        {
            _context.Remove(category);
        }

        public void Update(Category category)
        {
            _context.Update(category);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
