using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IReservationServices
    {
        Task<IEnumerable<ReservationDto>> GetAllAsync(IDictionary<string, string> query);
        Task<ReservationDto?> GetByIdAsync(Guid id);
        Task<ReservationDto> CreateAsync(AddReservationRequestDto dto);
        Task<ReservationDto?> UpdatedByIdAsync(Guid id,UpdateReservationRequestDto dto);
        Task<IEnumerable<ReservationDto>> GetAllByHotelIdAsync(Guid hotelId, IDictionary<string, string> query);

        Task<IEnumerable<ReservationCalendarDto>> GetAllReservationCalendarForRoom(Guid roomId, DateTime startDate, DateTime endDate);

        Task<bool> DeleteByIdAsync(Guid id);
    }
   
}
