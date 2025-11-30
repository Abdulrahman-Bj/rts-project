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
    public interface ICurrencyServices
    {
        Task<IEnumerable<CurrencyDto>> GetAllAsync(IDictionary<string, string> query);
        Task<CurrencyDto?> GetByIdAsync(Guid id);
        Task<CurrencyDto?> UpdateByIdAsync(Guid id, UpdateCurrencyRequestDto dto);
        Task<CurrencyDto> CreateAsync(AddCurrencyRequestDto dto);
        Task<bool> DeleteByIdAsync(Guid id);
    }

}
