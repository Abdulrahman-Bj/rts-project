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

namespace Application.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllAsync(IDictionary<string, string> queryParams);
        Task<ClientDto?> GetById(Guid id);
        Task<ClientDto?> UpdateByIdAsync(Guid id, UpdateClientRequestDto updateClientRequestDto);
        Task<ClientDto> CreateAsync(AddClientRequestDto addClientRequestDto);
        Task<bool> DeleteByIdAsync(Guid id);

    }
    public class ClientServices : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper mapper;
        public ClientServices(IClientRepository userRepository, IMapper mapper)
        {
            _clientRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> GetAllAsync(IDictionary<string, string> query)
        {
            var clients = await _clientRepository.GetAllAsync(query);

            return mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        public async Task<ClientDto?> GetById(Guid id)
        {
            var client = await _clientRepository.GetById(id);

            if (client == null)
            {
                return null;
            }

            var clientDto = mapper.Map<ClientDto>(client);
            return clientDto;
        }
        public async Task<ClientDto> CreateAsync(AddClientRequestDto addClientRequestDto)
        {
            var clientObject = mapper.Map<Client>(addClientRequestDto);

            var createdClient =  await _clientRepository.CreateAsync(clientObject);

            return mapper.Map<ClientDto>(createdClient);

        }

        public async Task<ClientDto?> UpdateByIdAsync(Guid id, UpdateClientRequestDto updateClientRequestDto)
        {
            var clientObject = mapper.Map<Client>(updateClientRequestDto);

            var updatedClient =  await _clientRepository.UpdateByIdAsync(id, clientObject);

            if (updatedClient == null)
            {
                return null;
            }
            return mapper.Map<ClientDto>(updatedClient);
        }
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _clientRepository.DeleteByIdAsync(id);
        }
    }
}
