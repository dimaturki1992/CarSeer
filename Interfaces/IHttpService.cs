namespace CarSeer.Interfaces
{
    public interface IHttpService
    {
        Task<T> GetApiResponseContent<T>(string apiUrl);
    }
}
