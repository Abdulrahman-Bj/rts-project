using Application.Converters;
using Application.DTOs;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICityServices
    {
        Task<IEnumerable<CityDto>> GetAllAsync();
        Task<CityDto?> GetById(Guid id);
        Task<CityDto?> UpdateByIdAsync(Guid id, UpdateCityRequestDto updateCityRequestDto);
        Task<CityDto> CreateAsync(AddCityRequestDto addCityRequestDto);
        Task<bool> DeleteByIdAsync(Guid id);

    }
    
}
