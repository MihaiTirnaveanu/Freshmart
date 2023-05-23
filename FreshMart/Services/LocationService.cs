using FreshMart.Models;
using FreshMart.Repositories.Interfaces;
using FreshMart.Services.Interfaces;
using Microsoft.CodeAnalysis;
using Location = FreshMart.Models.Location;

namespace FreshMart.Services
{
    public class LocationService : ILocationService
    {
        private ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;  
        }
        public void AddLocation(Location location)
        {
            _locationRepository.Create(location);
            _locationRepository.Save();
        }

        public void DeleteLocation(int id)
        {
            var location = _locationRepository.GetById(id);
            if (location != null)
            {
                _locationRepository.Delete(location);
                _locationRepository.Save();
            }
            
        }

        public List<Location> GetAllLocations()
        {
            return _locationRepository.GetAll().ToList();
        }

        public Location GetLocationById(int id)
        {
            return _locationRepository.GetById(id);
        }

        public bool LocationExists(int id)
        {
            return _locationRepository.LocationExists(id);
        }

        public void UpdateLocation(Location location)
        {
            _locationRepository.Update(location);
            _locationRepository.Save();
        }
    }
}
