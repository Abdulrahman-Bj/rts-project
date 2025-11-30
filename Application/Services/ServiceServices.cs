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
using Application.Interfaces;

namespace Application.Services
{
    public class ServiceServices : IServiceServices
    {
        private readonly IServiceRepository serviceRepository;
        private readonly IMapper mapper;
        private readonly IFileServices fileServices;

        public ServiceServices(IServiceRepository serviceRepository, IMapper mapper, IFileServices fileServices)
        {
            this.serviceRepository = serviceRepository;
            this.mapper = mapper;
            this.fileServices = fileServices;
        }
        public async Task<ServiceDto> CreateAsync(AddServiceRequestDto addServiceRequestDto)
        {
            if (addServiceRequestDto.IconFile?.Length > 1 * 1024 * 1024)
            {
                //return StatusCode(StatusCodes.Status400BadRequest, "File size is too big");
            }

            string[] allowedFileExtention = [".jpg", ".png", ".jpeg"];
            var createdFileName = await fileServices.SaveFileAsync(addServiceRequestDto.IconFile, allowedFileExtention, "Services");
            var service = mapper.Map<Service>(addServiceRequestDto);
            service.Icon = createdFileName;

            var createdService = await serviceRepository.CreatedAsync(service);


            return mapper.Map<ServiceDto>(createdService);

        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var service = await serviceRepository.GetByIdAsync(id);
            bool isDeleted = await serviceRepository.DeletebByIdAsync(id);

            if (!isDeleted)
            {
                return isDeleted;
            }


            if (service?.Icon != null)
                fileServices.DeleteFile(service.Icon, "Services");

            return true;
        }


        public async Task<IEnumerable<ServiceDto>> GetAllAsync(IDictionary<string, string> query)
        {
            var services = await serviceRepository.GetAllAsync(query);

            return mapper.Map<IEnumerable<ServiceDto>>(services);
        }

        public async Task<ServiceDto?> GetByIdAsync(Guid id)
        {
            var service = await serviceRepository.GetByIdAsync(id);

            return mapper.Map<ServiceDto?>(service);
        }

        public async Task<ServiceDto?> UpdateByIdAsync(Guid id, UpdateServiceRequestDto updateServiceRequestDto)
        {
            var oldService = await serviceRepository.GetByIdAsync(id);
            var service = mapper.Map<Service>(updateServiceRequestDto);

            if (updateServiceRequestDto.IconFile != null)
            {
                if (updateServiceRequestDto.IconFile?.Length > 1 * 1024 * 1024)
                {
                    //return 
                }

                string[] allowedFileExtention = [".jpg", ".png", ".jpeg"];
                var newImagePath = await fileServices.SaveFileAsync(updateServiceRequestDto.IconFile, allowedFileExtention, "Services");
                service.Icon = newImagePath;
            }

            var updatedService = await serviceRepository.UpdateByIdAsync(id, service);

            if (updateServiceRequestDto.IconFile != null)
                fileServices.DeleteFile(oldService.Icon, "Services");
            return mapper.Map<ServiceDto?>(updatedService);
        }

        
    }
}
