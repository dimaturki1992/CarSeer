using CarSeer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarSeer.Controllers
{
    [ApiController]
    [Route("api/models")]
    public class ModelsController : ControllerBase
    {
        private readonly ICarModelService _carModelService;
        private readonly ICarMakeInfoService _carMakeInfoService;

        public ModelsController(
        ICarModelService carModelService,
        ICarMakeInfoService carMakeInfoService
            )

        {
            _carModelService = carModelService;
            _carMakeInfoService = carMakeInfoService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] string make, [FromQuery] int modelyear)
        {
            int makeId = _carMakeInfoService.GetMakeId(make);
            var response = await _carModelService.GetModels(makeId, modelyear);
            return Ok(response);
        }
    }
}