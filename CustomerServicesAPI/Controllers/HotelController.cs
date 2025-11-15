using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServicesAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelServices hotelServices;

        public HotelController(IHotelServices hotelServices)
        {
            this.hotelServices = hotelServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdmins([FromQuery] string? name, [FromQuery] Guid? cityId, [FromQuery] string? page, string? limit, string? sort)
        {
            var queryParams = Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
            var hotels = await hotelServices.GetAllAsync(queryParams);
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var hotel = await hotelServices.GetById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddHotelRequestDto addHotelRequestDto)
        {
            var hotel = await hotelServices.CreateAsync(addHotelRequestDto);
            return CreatedAtAction(nameof(GetById), new { id = hotel.Id }, hotel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateHotelRequestDto updateHotelRequestDto)
        {
            var updatedHotel = await hotelServices.UpdateByIdAsync(id, updateHotelRequestDto);
            if (updatedHotel == null)
            {
                return NotFound();
            }
            return Ok(updatedHotel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await hotelServices.DeleteByIdAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
