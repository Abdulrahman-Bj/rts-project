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
    public interface IAdminServices
    {
        Task<IEnumerable<AdminDto>> GetAllAsync(IDictionary<string, string> query);

        Task<AdminDto?> GetById(Guid id);
        Task<AdminDto> CreateAsync(AddAdminRequestDto addAdminRequestDto);
        Task<AdminDto?> UpdateByIdAsync(Guid id, UpdateAdminRequestDto updateAdminRequestDto);
           Task<bool> DeleteByIdAsync(Guid id);
    }
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepository adminRepository;
        private readonly IMapper mapper;

        public AdminServices(IAdminRepository adminRepository, IMapper mapper)
        {
            this.adminRepository = adminRepository;
            this.mapper = mapper;
        }

        public async Task<AdminDto> CreateAsync(AddAdminRequestDto addAdminRequestDto)
        {
            // input validation

            if (addAdminRequestDto.Password != addAdminRequestDto.PasswordConfirm)
            {
                throw new ArgumentException("Password and PasswordConfirm do not match.");
            }

            var adminEntity = mapper.Map<Admin>(addAdminRequestDto);

            var createdAdmin = await adminRepository.CreateAsync(adminEntity);

            return mapper.Map<AdminDto>(createdAdmin);

        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await adminRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<AdminDto>> GetAllAsync(IDictionary<string, string> query)
        {
            var admins = await adminRepository.GetAllAsync(query);

            return mapper.Map<IEnumerable<AdminDto>>(admins);
        }

        public async Task<AdminDto?> GetById(Guid id)
        {
            var admin = await adminRepository.GetByIdAsync(id);

            if (admin == null)
            {
                return null;
            }

            return mapper.Map<AdminDto>(admin);
        }

        public async Task<AdminDto?> UpdateByIdAsync(Guid id, UpdateAdminRequestDto updateAdminRequestDto)
        {

            var updatedAdmin = mapper.Map<Admin>(updateAdminRequestDto);
            var admin = await adminRepository.UpdateByIdAsync(id, updatedAdmin);

            if (admin == null)
            {
                return null;
            }
            return mapper.Map<AdminDto>(admin);
        }
    }
}
