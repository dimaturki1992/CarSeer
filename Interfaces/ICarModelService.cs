using CarSeer.Models;

namespace CarSeer.Interfaces
{
    public interface ICarModelService
    {
        Task<CarModelsResponseDTO> GetModels(int makeId, int year);
    }
}
