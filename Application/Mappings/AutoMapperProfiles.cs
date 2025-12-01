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
            CreateMap<AddHotelRequestDto, Hotel>().ForMember(dest => dest.CoverImage, opt => opt.Ignore())
                .ForMember(dest => dest.Images, opt => opt.Ignore());;
            CreateMap<UpdateHotelRequestDto, Hotel>().ReverseMap();
            CreateMap<HotelImage, HotelImageDto>().ReverseMap();

            // vender mappings
            CreateMap<Vender, VenderDto>().ReverseMap();
            CreateMap<AddVenderRequestDto, Vender>().ReverseMap();
            CreateMap<UpdateVenderRequestDto, Vender>().ReverseMap();

            // room mappings
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<AddRoomRequestDto, Room>().ForMember(dest => dest.CoverImage, opt => opt.Ignore())
            .ForMember(dest => dest.Images, opt => opt.Ignore());
            CreateMap<UpdateRoomRequestDto, Room>().ReverseMap();
            CreateMap<Room, GetRoomResponseDto>().ForMember(dest => dest.ConvertedDailyPrice, opt => opt.MapFrom((src, dest, destMember, context) => src.ApplyDiscount(src.DailyPrice) / (decimal)context.Items["Rate"])).
                ForMember(dest => dest.ConvertedWeeklyPrice, opt => opt.MapFrom((src, dest, destMember, context) => src.ApplyDiscount(src.WeeklyPrice) / (decimal)context.Items["Rate"])).
                ForMember(dest => dest.ConvertedMonthlyPrice, opt => opt.MapFrom((src, dest, destMember, context) => src.ApplyDiscount(src.MonthlyPrice) / (decimal)context.Items["Rate"]));
            CreateMap<RoomImage, RoomImageDto>().ReverseMap();

            // service mappings
            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<AddServiceRequestDto, Service>().ReverseMap();
            CreateMap<UpdateServiceRequestDto, Service>().ReverseMap();

            // reservation mappings
            CreateMap<AddReservationRequestDto, Reservation>().ReverseMap();
            CreateMap<UpdateReservationRequestDto, Reservation>().ReverseMap();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<Reservation, ReservationCalendarDto>().ReverseMap();

            // currency mappings
            CreateMap<AddCurrencyRequestDto, Currency>().ReverseMap();
            CreateMap<UpdateCurrencyRequestDto, Currency>().ReverseMap();
            CreateMap<Currency, CurrencyDto>().ReverseMap();
        }
    }
}
