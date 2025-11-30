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
    public interface IVenderServices
    {
        Task<IEnumerable<VenderDto>> GetAllAsync(IDictionary<string, string> query);

        Task<VenderDto?> GetById(Guid id);
        Task<VenderDto> CreateAsync(AddVenderRequestDto addVenderRequestDto);
        Task<VenderDto?> UpdateByIdAsync(Guid id, UpdateVenderRequestDto updateVenderRequestDto);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
