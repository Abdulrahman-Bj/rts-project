using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServiceServices
    {
        Task<IEnumerable<ServiceDto>> GetAllAsync(IDictionary<string, string> query);
        Task<ServiceDto?> GetByIdAsync(Guid id);
        Task<ServiceDto> CreateAsync(AddServiceRequestDto addServiceRequestDto);
        Task<ServiceDto?> UpdateByIdAsync(Guid id, UpdateServiceRequestDto updateServiceRequestDto);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
