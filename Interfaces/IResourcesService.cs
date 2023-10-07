using CarSeer.Models;

namespace CarSeer.Interfaces
{
    public interface IResourcesService
    {
        List<CarMakeInfo> GetMakeInfo();
    }
}
