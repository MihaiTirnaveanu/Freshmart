using FreshMart.Models;

namespace FreshMart.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAll();
        Location GetById(int id);

        bool LocationExists(int id);
        void Create(Location location);
        void Update(Location location);
        void Delete(Location location);

        void Save();
    }
}
