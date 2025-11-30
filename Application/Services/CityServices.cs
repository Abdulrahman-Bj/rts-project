using Application.Converters;
using Application.DTOs;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;


namespace Application.Services
{
    public class CityServices : ICityServices
    {
        private readonly ICityRepository _cityRepository;
        public CityServices(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<IEnumerable<CityDto>> GetAllAsync()
        {
            var cities = await _cityRepository.GetAllAsync();

            var citiesDto = cities.Select(city => new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                CreatedAt = city.CreatedAt,
                UpdatedAt = city.UpdatedAt
            });

            return citiesDto;
        }

        public async Task<CityDto> CreateAsync(AddCityRequestDto addCityRequestDto)
        {
            var cityObject = addCityRequestDto.ToCityEntity();

            var createdCity = await _cityRepository.CreateAsync(cityObject);

            return createdCity.ToCityDto();
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _cityRepository.DeleteByIdAsync(id);
        }


        public async Task<CityDto?> GetById(Guid id)
        {
            var city = await _cityRepository.GetById(id);

            if (city == null)
            {
                return null;
            }

            var cityDto = new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                CreatedAt = city.CreatedAt,
                UpdatedAt = city.UpdatedAt
            };
            return cityDto;
        }

        public async Task<CityDto?> UpdateByIdAsync(Guid id, UpdateCityRequestDto updateCityRequestDto)
        {
            var cityObject = updateCityRequestDto.ToUpdateCityEntity();

            var updatedcity = await _cityRepository.UpdateByIdAsync(id, cityObject);

            if (updatedcity == null)
            {
                return null;
            }

            return updatedcity.ToCityDto();
        }
    }
}
