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
    public static class UserConverter
    {

        public static User ToUpdateUserEntity(this UpdateUserRequestDto dto)
        {
            return new User
            {
                Username = dto.Username,
                Password = dto.Password,
                Name = dto.Name,
                CityId = dto.CityId,
                Type = dto.Type,
                UpdateAt = dto.UpdateAt
            };
        }
        public static User ToUserEntity (this AddUserRequestDto dto)
        {
            return new User
            {
                Username = dto.Username,
                Password = dto.Password,
                Name = dto.Name,
                CityId = dto.CityId,
                Type = dto.Type,
            };
        }



        public static UserDto ToUserDto (this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                CityId = user.CityId,
                Type = user.Type,
                CreatedAt = user.CreatedAt,
                UpdateAt = user.UpdateAt
            };
        }

        public static IServiceCollection AddUserService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserServices>();

            return services;
        }
    }
}
