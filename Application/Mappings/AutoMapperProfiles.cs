using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // client mappings
            CreateMap<Client, AddClientRequestDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Client, UpdateClientRequestDto>().ReverseMap();

            // admin mappings
            CreateMap<AddAdminRequestDto, Admin>().ReverseMap();
            CreateMap<UpdateAdminRequestDto, Admin>().ReverseMap();
            CreateMap<Admin, AdminDto>().ReverseMap();

            // city mappings
            CreateMap<City, CityDto>().ReverseMap();

            // hotel mappings
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<AddHotelRequestDto, Hotel>().ReverseMap();
            CreateMap<UpdateHotelRequestDto, Hotel>().ReverseMap();

            // vender mappings
            CreateMap<Vender, VenderDto>().ReverseMap();
            CreateMap<AddVenderRequestDto, Vender>().ReverseMap();
            CreateMap<UpdateVenderRequestDto, Vender>().ReverseMap();

            // room mappings
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<AddRoomRequestDto, Room>().ReverseMap();
            CreateMap<UpdateRoomRequestDto, Room>().ReverseMap();
        }
    }
}
