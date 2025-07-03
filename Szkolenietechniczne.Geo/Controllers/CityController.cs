using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using Szkolenietechniczne.Geo.Services;

namespace Szkolenietechniczne.Geo.Controllers
{
    [Route("/geo")]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        
        [HttpGet("cities")]
        public async Task<IEnumerable<CityDto>> Read() => await _cityService.Get();
       

        [HttpGet("cities/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var cityDto = await _cityService.GetById(id);

            if (cityDto == null)
            {
                return NotFound();
            }

            return Ok(cityDto);
        }

        
        [HttpPost("city")]
        public async Task<IActionResult> Create([FromBody] CityDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operationResult = await _cityService.Create(dto);

            return Ok(operationResult.Result);
        }
    }
}
