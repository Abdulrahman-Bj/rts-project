using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Exceptions;

namespace Application.Services
{
    public class ReservationServices : IReservationServices
    {
        private readonly IReservationRepository reservationRepository;
        private readonly IMapper mapper;

        public ReservationServices(IReservationRepository reservationRepository, IMapper mapper)
        {
            this.reservationRepository = reservationRepository;
            this.mapper = mapper;
        }
        public async Task<ReservationDto> CreateAsync(AddReservationRequestDto dto)
        {

            var conflictReservations = await GetAllReservationCalendarForRoom(dto.RoomId, dto.StartedAt, dto.EndedAt);

            if (conflictReservations != null && conflictReservations.Any(r => r.IsReserved == true))
            {
                throw new InputValidationException("there is already resrvation at this duration");
            }

            var resrvationDomain = mapper.Map<Reservation>(dto);
            var createdReservation = await reservationRepository.CreateAsync(resrvationDomain);

            return mapper.Map<ReservationDto>(createdReservation);
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await reservationRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<ReservationDto>> GetAllAsync(IDictionary<string, string> query)
        {
            var reservations = await reservationRepository.GetAllAsync(query);

            return mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }

        public async Task<IEnumerable<ReservationDto>> GetAllByHotelIdAsync(Guid hotelId, IDictionary<string, string> query)
        {
            var reservations = await reservationRepository.GetAllHotelReservationsAsync(hotelId, query);

            return mapper.Map<IEnumerable<ReservationDto>>(reservations);

        }

        public async Task<IEnumerable<ReservationCalendarDto>> GetAllReservationCalendarForRoom(Guid roomId, DateTime startDate, DateTime endDate)
        {
            var reservations = await reservationRepository.GetOverLappingReservationAsync(roomId, startDate, endDate);

            var results = new List<ReservationCalendarDto>();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (reservations.Any(r => r.StartedAt <= date && r.EndedAt >= date))
                {
                    results.Add(new ReservationCalendarDto
                    {
                        Date = new DateOnly(date.Year, date.Month, date.Day),
                        IsReserved = true

                    });
                }
                else
                {
                    results.Add(new ReservationCalendarDto
                    {
                        Date = new DateOnly(date.Year, date.Month, date.Day),
                        IsReserved = false

                    });

                }

            }

            return results;
        }

        public async Task<ReservationDto?> GetByIdAsync(Guid id)
        {
            var reservation = await reservationRepository.GetByIdAsync(id);
            if (reservation == null)
            {
                return null;
            }

            return mapper.Map<ReservationDto>(reservation);
        }

        public async Task<ReservationDto?> UpdatedByIdAsync(Guid id,UpdateReservationRequestDto dto)
        {
            var reservationDomain = mapper.Map<Reservation>(dto);
            var reservation = await reservationRepository.UpdateByIdAsync(id, reservationDomain);
            if (reservation == null)
            {
                return null;
            }

            return mapper.Map<ReservationDto>(reservation);
        }
    }
}
