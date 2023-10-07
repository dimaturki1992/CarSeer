using CarSeer.Interfaces;
using CarSeer.Models;
using CarSeer.Models.ExtAPI;
using Newtonsoft.Json;

namespace CarSeer.Services
{
    public class CarModelService : ICarModelService
    {
        private readonly HttpClient _httpClient;
        private const string vehiclesApiBaseUrl = "https://vpic.nhtsa.dot.gov/api/vehicles/";

        public CarModelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CarModelsResponseDTO> GetModels(int makeId, int year)
        {
            var apiUrl = $"{vehiclesApiBaseUrl}GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}?format=json";
            var response = await _httpClient.GetAsync(apiUrl);
            var content = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<CarModelsAPIResponseDTO>(content);
            CarModelsResponseDTO models = new CarModelsResponseDTO()
            {
                Models = apiResponse.Results.Select(record => record.Model_Name).ToList()
            };
            return models;

        }
    }
}
