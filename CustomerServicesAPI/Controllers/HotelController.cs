using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServicesAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HotelController : BaseController
    {
        private readonly IHotelServices hotelServices;
        private readonly IRoomServices roomServices;

        public HotelController(IHotelServices hotelServices, IRoomServices roomServices)
        {
            this.hotelServices = hotelServices;
            this.roomServices = roomServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdmins([FromQuery] string? name, [FromQuery] Guid? cityId, [FromQuery] string? page, string? limit, string? sort)
        {
            var queryParams = Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
            var hotels = await hotelServices.GetAllAsync(queryParams);
            return ApiOk(hotels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var hotel = await hotelServices.GetById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return ApiOk(hotel);
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
            return ApiOk(updatedHotel);
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

        [HttpGet]
        [Route("{hotelId}/rooms")]
        public async Task<IActionResult> GetAllRoomsByHotelId([FromRoute] Guid hotelId,[FromQuery] Guid currencyId,string? name, string? page, string? limit, string? sort)
        {
            var queryParams = Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
            var rooms = await roomServices.GetRoomsByHotelIdAsync(hotelId, queryParams);
            return ApiOk(rooms);
        }
    }
}
