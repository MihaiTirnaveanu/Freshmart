using FreshMart.Models;

namespace FreshMart.Services.Interfaces
{
    public interface ILocationService
    { 
        List<Location> GetAllLocations();
        Location GetLocationById(int id);
        bool LocationExists(int id);
        void AddLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(int id);
    }
}
