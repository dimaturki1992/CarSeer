using CarSeer.Interfaces;
using Newtonsoft.Json;

namespace CarSeer.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetApiResponseContent<T>(string apiUrl)
        {
            var response = await _httpClient.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Http request failed with status code {response.StatusCode}.");
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
