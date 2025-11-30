using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Services
{
    public class VenderServices : IVenderServices
    {
        private readonly IVenderRepository venderRepository;
        private readonly IMapper mapper;

        public VenderServices(IVenderRepository venderRepository, IMapper mapper)
        {
            this.venderRepository = venderRepository;
            this.mapper = mapper;
        }
        public async Task<VenderDto> CreateAsync(AddVenderRequestDto addVenderRequestDto)
        {
            // input validation

            if (addVenderRequestDto.Password != addVenderRequestDto.PasswordConfirm)
            {
                throw new ArgumentException("Password and PasswordConfirm do not match.");
            }

            var venderEntity = mapper.Map<Vender>(addVenderRequestDto);
            var createdVender = await venderRepository.CreateAsync(venderEntity);

            return mapper.Map<VenderDto>(createdVender);

        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await venderRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<VenderDto>> GetAllAsync(IDictionary<string, string> query)
        {
            var venders = await venderRepository.GetAllAsync(query);

            return mapper.Map<IEnumerable<VenderDto>>(venders);
        }

        public async Task<VenderDto?> GetById(Guid id)
        {
            var vender = await venderRepository.GetByIdAsync(id);

            if (vender == null)
            {
                return null;
            }

            return mapper.Map<VenderDto>(vender);
        }

        public async Task<VenderDto?> UpdateByIdAsync(Guid id, UpdateVenderRequestDto updateVenderRequest)
        {

            var updatedVender = mapper.Map<Vender>(updateVenderRequest);
            var vender = await venderRepository.UpdateByIdAsync(id, updatedVender);

            if (vender == null)
            {
                return null;
            }
            return mapper.Map<VenderDto>(vender);
        }
    }
}
