using CarSeer.Interfaces;
using CarSeer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        public async Task<IActionResult> Get([FromQuery][BindRequired] string make, [FromQuery][BindRequired] int modelYear)
        {
            try
            {
                int makeId = _carMakeInfoService.GetMakeId(make);
                CarModelsResponseDTO response = await _carModelService.GetModels(makeId, modelYear);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}