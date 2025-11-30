using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServicesAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RoomsController : BaseController
    {
        private readonly IRoomServices roomServices;
        private readonly IReservationServices reservationServices;

        public RoomsController(IRoomServices roomServices, IReservationServices reservationServices)
        {
            this.roomServices = roomServices;
            this.reservationServices = reservationServices;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAdmins([FromQuery] string? name, [FromQuery] string? type, [FromQuery] string? page, string? limit, string? sort)
        {
            var queryParams = Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
            var rooms = await roomServices.GetAllAsync(queryParams);

            return ApiOk(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, [FromQuery] Guid currencyId)
        {
            var room = await roomServices.GetById(id, currencyId);
            if (room == null)
            {
                return NotFound();
            }
            return ApiOk(room);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddRoomRequestDto addRoomRequestDto)
        {
            var room = await roomServices.CreateAsync(addRoomRequestDto);
            return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateRoomRequestDto updateRoomRequest)
        {
            var updatedRoom = await roomServices.UpdateByIdAsync(id, updateRoomRequest);
            if (updatedRoom == null)
            {
                return NotFound();
            }
            return ApiOk(updatedRoom);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await roomServices.DeleteByIdAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{roomId}/availability")]

        public async Task<IActionResult> CheckCheckRoomAvailability(Guid roomId, [FromQuery] DateTime startedAt, [FromQuery] DateTime endedAt)
        {
            var dates = await reservationServices.GetAllReservationCalendarForRoom(roomId, startedAt, endedAt);

            return ApiOk(dates);
        }

    }
}
