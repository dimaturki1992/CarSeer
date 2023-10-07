using CarSeer.Interfaces;
using CarSeer.Models;
using CarSeer.Models.ExtAPI;

namespace CarSeer.Services
{
    public class CarModelService : ICarModelService
    {
        private readonly IHttpService _httpService;
        private const string vehiclesApiBaseUrl = "https://vpic.nhtsa.dot.gov/api/vehicles/";

        public CarModelService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<CarModelsResponseDTO> GetModels(int makeId, int year)
        {
            var apiUrl = $"{vehiclesApiBaseUrl}GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}?format=json";
            CarModelsAPIResponseDTO apiResponse = await _httpService.GetApiResponseContent<CarModelsAPIResponseDTO>(apiUrl);
            CarModelsResponseDTO carModelsResponse = new CarModelsResponseDTO()
            {
                Models = apiResponse.Results.Select(record => record.Model_Name).ToList()
            };
            return carModelsResponse;

        }
    }
}
