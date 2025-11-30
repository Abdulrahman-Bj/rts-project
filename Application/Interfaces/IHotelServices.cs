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
    public interface IHotelServices
    {
        Task<IEnumerable<HotelDto>> GetAllAsync(IDictionary<string, string> query);

        Task<HotelDto?> GetById(Guid id);
        Task<HotelDto> CreateAsync(AddHotelRequestDto addHotelRequestDto);
        Task<HotelDto?> UpdateByIdAsync(Guid id, UpdateHotelRequestDto updateHotelRequest);
        Task<bool> DeleteByIdAsync(Guid id);

    }
}
