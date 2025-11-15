using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IRoomServices
    {
        Task<IEnumerable<RoomDto>> GetAllAsync(IDictionary<string, string> query);

        Task<RoomDto?> GetById(Guid id);
        Task<RoomDto> CreateAsync(AddRoomRequestDto addRoomRequestDto);
        Task<RoomDto?> UpdateByIdAsync(Guid id, UpdateRoomRequestDto updateRoomRequest);
        Task<bool> DeleteByIdAsync(Guid id);
    }
    public class RoomServices : IRoomServices
    {
        private readonly IRoomRepository roomRepository;
        private readonly IMapper mapper;

        public RoomServices(IRoomRepository roomRepository, IMapper mapper)
        {
            this.roomRepository = roomRepository;
            this.mapper = mapper;
        }


        public async Task<RoomDto> CreateAsync(AddRoomRequestDto addRoomRequestDto)
        {
            var roomEntity = mapper.Map<Room>(addRoomRequestDto);

            var createdRoom = await roomRepository.CreateAsync(roomEntity);

            return mapper.Map<RoomDto>(createdRoom);
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await roomRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync(IDictionary<string, string> query)
        {
            var rooms = await roomRepository.GetAllAsync(query);

            return mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        public async Task<RoomDto?> GetById(Guid id)
        {
            var room = await roomRepository.GetByIdAsync(id);

            if (room == null)
            {
                return null;
            }

            var roomDto = mapper.Map<RoomDto>(room);
            return roomDto;
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
    }
}
