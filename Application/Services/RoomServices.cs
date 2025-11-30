using Application.DTOs;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;


using Domain.Constants;
using Infrastructure.Services;

namespace Application.Services
{
    public class RoomServices : IRoomServices
    {
        private readonly IRoomRepository roomRepository;
        private readonly IMapper mapper;
        private readonly ICurrencyServices currencyServices;
        private readonly IFileServices fileServices;

        public RoomServices(IRoomRepository roomRepository, IMapper mapper, ICurrencyServices currencyServices, IFileServices fileServices)
        {
            this.roomRepository = roomRepository;
            this.mapper = mapper;
            this.currencyServices = currencyServices;
            this.fileServices = fileServices;
        }


        public async Task<RoomDto> CreateAsync(AddRoomRequestDto addRoomRequestDto)
        {
            var roomEntity = mapper.Map<Room>(addRoomRequestDto);

            var images = new List<RoomImage>();
            string[] allowedImages = { ".jpg", ".jgpj" };
            foreach (var image in addRoomRequestDto.Images)
            {
                var name = await fileServices.SaveFileAsync(image, allowedImages, "Rooms");
                images.Add(new RoomImage
                {
                    Name = name,
                });
            }
            roomEntity.Images = images;
            roomEntity.CoverImage = images.First();
            var createdRoom = await roomRepository.CreateAsync(roomEntity, addRoomRequestDto.ServiceIds);

            return mapper.Map<RoomDto>(createdRoom);
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await roomRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<GetRoomResponseDto>> GetAllAsync(IDictionary<string, string> query)
        {
            var rate = await GetCurrencyExchangeRateAsync(query);
            var rooms = await roomRepository.GetAllAsync(query);
            var mappedRooms = mapper.Map<IEnumerable<GetRoomResponseDto>>(rooms, opt => opt.Items["Rate"] = rate);

            return mappedRooms;
        }

        public async Task<GetRoomResponseDto?> GetById(Guid id, Guid currencyId)
        {

            var currency = await currencyServices.GetByIdAsync(currencyId);
            var room = await roomRepository.GetByIdAsync(id);
            if (room == null)
            {
                throw new InputValidationException(Constants.ROOM_NOT_FOUND);
            }

            var roomDto = mapper.Map<GetRoomResponseDto>(room, opt => opt.Items["Rate"] = currency?.ExchangeRateToDefault ?? 1m);
            return roomDto;
        }

        public async Task<IEnumerable<GetRoomResponseDto>> GetRoomsByHotelIdAsync(Guid hotelId, IDictionary<string, string> query)
        {
            var rate = await GetCurrencyExchangeRateAsync(query);
            var roomsDomain = await roomRepository.GetRoomsByHotelIdAsync(hotelId, query);
            var mappedRooms = mapper.Map<IEnumerable<GetRoomResponseDto>>(roomsDomain, otp => otp.Items["Rate"] = rate);

            return mappedRooms;
        }

        public async Task<RoomDto?> UpdateByIdAsync(Guid id, UpdateRoomRequestDto updateRoomRequestDto)
        {
            var roomEntity = mapper.Map<Room>(updateRoomRequestDto);
            var updatedRoom = await roomRepository.UpdateByIdAsync(id, roomEntity);

            if (updatedRoom == null)
            {
                return null;
            }
            return mapper.Map<RoomDto>(updatedRoom);
        }


        private  async Task<decimal> GetCurrencyExchangeRateAsync(IDictionary<string, string> query)
        {
            decimal rate = 1;
            if (query.TryGetValue("currencyId", out string currencyString) && Guid.TryParse(currencyString, out Guid currency))
            {
                var obj = await currencyServices.GetByIdAsync(currency);
                rate = obj?.ExchangeRateToDefault ?? 1m;
                query.Remove("currencyId");

            }

            return rate;

        }
    }

}
