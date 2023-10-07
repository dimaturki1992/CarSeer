using CarSeer.Interfaces;
using CarSeer.Models;
using System.Text.RegularExpressions;

namespace CarSeer.Services
{
    public class CarMakeInfoService : ICarMakeInfoService
    {
        private readonly IResourcesService _resourcesService;
        private List<CarMakeInfo> _makeIdNamePairs;

        public CarMakeInfoService(
            IResourcesService resourcesService
            )
        {
            _resourcesService = resourcesService;
        }

        public int GetMakeId(string make)
        {
            var data = GetIdNamePairs();
            string sanitizedMake = make.SanitizeInput();
            var matchingRow = data.FirstOrDefault(row => row.Name.SanitizeInput() == sanitizedMake);
            if (matchingRow != null)
            {
                return matchingRow.Id;
            }
            throw new Exception("Car model does not exist.");
        }

        private List<CarMakeInfo> GetIdNamePairs()
        {
            if (_makeIdNamePairs == null)
            {
                _makeIdNamePairs = _resourcesService.GetMakeInfo();
            }
            return _makeIdNamePairs;

        }


    }
}
