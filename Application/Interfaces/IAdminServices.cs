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
    public interface IAdminServices
    {
        Task<IEnumerable<AdminDto>> GetAllAsync(IDictionary<string, string> query);

        Task<AdminDto?> GetById(Guid id);
        Task<AdminDto> CreateAsync(AddAdminRequestDto addAdminRequestDto);
        Task<AdminDto?> UpdateByIdAsync(Guid id, UpdateAdminRequestDto updateAdminRequestDto);
           Task<bool> DeleteByIdAsync(Guid id);
    }
}
