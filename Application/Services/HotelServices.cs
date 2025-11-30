using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Services
{
    public class HotelServices : IHotelServices
    {
        private readonly IHotelRepository hotelRepository;
        private readonly IMapper mapper;

        public HotelServices(IHotelRepository hotelRepository, IMapper mapper)
        {
            this.hotelRepository = hotelRepository;
            this.mapper = mapper;
        }

        public async Task<HotelDto> CreateAsync(AddHotelRequestDto addHotelRequestDto)
        {
            var hotelEntity = mapper.Map<Hotel>(addHotelRequestDto);

            var createdHotel = await hotelRepository.CreateAsync(hotelEntity);

            return mapper.Map<HotelDto>(createdHotel);
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await hotelRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<HotelDto>> GetAllAsync(IDictionary<string, string> query)
        {
            var hotels = await hotelRepository.GetAllAsync(query);

            return mapper.Map<IEnumerable<HotelDto>>(hotels);
        }

        public async Task<HotelDto?> GetById(Guid id)
        {
            var hotel = await hotelRepository.GetByIdAsync(id);

            if (hotel == null)
            {
                return null;
            }

            var hotelDto = mapper.Map<HotelDto>(hotel);
            return hotelDto;
        }

        public async Task<HotelDto?> UpdateByIdAsync(Guid id, UpdateHotelRequestDto updateHotelRequest)
        {
            var hotelEntity = mapper.Map<Hotel>(updateHotelRequest);

            var updatedHotel = await hotelRepository.UpdateByIdAsync(id, hotelEntity);

            if (updatedHotel == null)
            {
                return null;
            }
            return mapper.Map<HotelDto>(updatedHotel);
        }
    }
}
