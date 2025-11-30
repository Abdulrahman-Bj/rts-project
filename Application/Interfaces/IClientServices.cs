using Application.Converters;
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
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllAsync(IDictionary<string, string> queryParams);
        Task<ClientDto?> GetById(Guid id);
        Task<ClientDto?> UpdateByIdAsync(Guid id, UpdateClientRequestDto updateClientRequestDto);
        Task<ClientDto> CreateAsync(AddClientRequestDto addClientRequestDto);
        Task<bool> DeleteByIdAsync(Guid id);

    }
}
