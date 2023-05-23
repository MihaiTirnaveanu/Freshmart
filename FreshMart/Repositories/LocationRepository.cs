using FreshMart.Data;
using FreshMart.Models;
using FreshMart.Repositories.Interfaces;

namespace FreshMart.Repositories
{
    public class LocationRepository:ILocationRepository
    {
        private SupermarketContext _context;
        public LocationRepository(SupermarketContext context)
        {
            _context = context;

        }
        public IEnumerable<Location> GetAll()
        {
            return _context.Locations.ToList();
        }

        public Location GetById(int id)
        {
            return _context.Locations.FirstOrDefault(c => c.Id == id);
        }

        public bool LocationExists(int id)
        {
            return _context.Locations.Any(c => c.Id == id);
        }

        public void Create(Location location)
        {
            _context.Locations.Add(location);
        }

        public void Delete(Location location)
        {
            _context.Remove(location);
        }

        public void Update(Location location)
        {
            _context.Update(location);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
