using CarSeer.Interfaces;
using CarSeer.Models;

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
            var matchingRow = data.FirstOrDefault(row => row.Name.ToLower() == make.ToLower());
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
