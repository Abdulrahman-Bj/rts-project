using Application.DTOs;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


using Domain.Constants;

namespace Application.Interfaces
{
    public interface IRoomServices
    {
        Task<IEnumerable<GetRoomResponseDto>> GetAllAsync(IDictionary<string, string> query);

        Task<GetRoomResponseDto?> GetById(Guid id, Guid currencyId);
        Task<RoomDto> CreateAsync(AddRoomRequestDto addRoomRequestDto);
        Task<RoomDto?> UpdateByIdAsync(Guid id, UpdateRoomRequestDto updateRoomRequest);
        Task<bool> DeleteByIdAsync(Guid id);

        Task<IEnumerable<GetRoomResponseDto>> GetRoomsByHotelIdAsync(Guid hotelId, IDictionary<string, string> query);
    }
}
