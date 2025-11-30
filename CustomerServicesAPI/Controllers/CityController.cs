using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServicesAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CityController : BaseController
    {
        private readonly ICityServices cityService;

        public CityController(ICityServices cityService) 
        { 
            this.cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await cityService.GetAllAsync();
            return ApiOk(cities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(Guid id)
        {
            var city = await cityService.GetById(id);
            if (city == null)
            {
                return NotFound();
            }
            return ApiOk(city);
        }

        [HttpPost]
        public async Task<IActionResult> create(AddCityRequestDto addCityRequestDto)
        {
            var city = await cityService.CreateAsync(addCityRequestDto);
            return CreatedAtAction(nameof(GetCityById), new { id = city.Id }, city);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(Guid id, UpdateCityRequestDto updateCityRequestDto)
        {
            var updatedCity = await cityService.UpdateByIdAsync(id, updateCityRequestDto);
            if (updatedCity == null)
            {
                return NotFound();
            }
            return ApiOk(updatedCity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            var isDeleted = await cityService.DeleteByIdAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
