using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Converters
{
    public static class CityConverter
    {
        public static City ToUpdateCityEntity(this UpdateCityRequestDto dto)
        {
            return new City
            {
                Name = dto.Name,
            };
        }
        public static City ToCityEntity(this AddCityRequestDto dto)
        {
            return new City
            {
                Name = dto.Name,
            };
        }



        public static CityDto ToCityDto(this City city)
        {
            return new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                CreatedAt = city.CreatedAt,
                UpdateAt = city.UpdateAt
            };
        }

        public static IServiceCollection AddCityService(this IServiceCollection services)
        {
            services.AddScoped<ICityService, CityServices>();

            return services;
        }
    }
}
