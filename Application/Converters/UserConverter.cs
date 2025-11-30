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

        //public static User ToUpdateUserEntity(this UpdateClientRequestDto dto)
        //{
        //    return new User
        //    {
        //        Username = dto.Username,
        //        Password = dto.Password,
        //        Name = dto.Name,
        //        CityId = dto.CityId,
        //        Type = dto.Type,
        //        UpdatedAt = dto.UpdatedAt
        //    };
        //}
        //public static User ToUserEntity (this AddClientRequestDto dto)
        //{
        //    return new User
        //    {
        //        Username = dto.Username,
        //        Password = dto.Password,
        //        Name = dto.Name,
        //        CityId = dto.CityId,
        //        Type = dto.Type,
        //    };
        //}



        //public static ClientDto ToUserDto (this User user)
        //{
        //    return new ClientDto
        //    {
        //        Id = user.Id,
        //        Username = user.Username,
        //        Name = user.Name,
        //        CityId = user.CityId,
        //        Type = user.Type,
        //        CreatedAt = user.CreatedAt,
        //        UpdatedAt = user.UpdatedAt
        //    };
        //}

        //public static IServiceCollection AddUserService(this IServiceCollection services)
        //{
        //    services.AddScoped<IClientService, ClientServices>();

        //    return services;
        //}
    }
}
