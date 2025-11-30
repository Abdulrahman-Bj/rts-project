using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServicesAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReservationController : BaseController
    {
        private readonly IReservationServices reservationServices;

        public ReservationController(IReservationServices reservationServices)
        {
            this.reservationServices = reservationServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] Guid? userId,[FromQuery] string? status,[FromQuery] string? page,[FromQuery] string? limit,[FromQuery] string? sort)
        {
            var query = Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
            var reservations = await reservationServices.GetAllAsync(query);

            return ApiOk(reservations);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var reservation = await reservationServices.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound("no reservation found");
            }
            return ApiOk(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddReservationRequestDto dto)
        {
 

            var reservation = await reservationServices.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new {id = reservation.Id}, reservation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateById([FromRoute] Guid id, UpdateReservationRequestDto dto)
        {
            var reservation = await reservationServices.UpdatedByIdAsync(id, dto);
            if (reservation == null)
            {
                return NotFound("no reservation found");
            }

            return ApiOk(reservation);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var reservation = await reservationServices.DeleteByIdAsync(id);
            if (!reservation)
            {
                return NotFound("No reservation found");
            }
            return ApiOk(reservation);
        }
        [HttpGet("{hotelId}/hotel")]
        public async Task<IActionResult> GetAllHotelReservation([FromRoute] Guid hotelId, [FromQuery] Guid? userId, string? status, string? page, string? limit, string? sort)
        {
            var query = Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
            var reservations = await reservationServices.GetAllByHotelIdAsync(hotelId, query);

            return ApiOk(reservations);
        }


    }
}
