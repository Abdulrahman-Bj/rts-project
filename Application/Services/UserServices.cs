using Application.Converters;
using Application.DTOs;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetById(Guid id);
        Task<UserDto?> UpdateByIdAsync(Guid id, UpdateUserRequestDto updateUserRequestDto);
        Task<UserDto> CreateAsync(AddUserRequestDto addUserRequestDto);
        Task<bool> DeleteByIdAsync(Guid id);

    }
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            var usersDto = users.Select(user => new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                CityId = user.CityId,
                Type = user.Type,
                CreatedAt = user.CreatedAt,
                UpdateAt = user.UpdateAt
            });

            return usersDto;
        }
        public async Task<UserDto?> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return null;
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                CityId = user.CityId,
                Type = user.Type,
                CreatedAt = user.CreatedAt,
                UpdateAt = user.UpdateAt
            };
            return userDto;
        }
        public async Task<UserDto> CreateAsync(AddUserRequestDto addUserRequestDto)
        {
            var userObject = addUserRequestDto.ToUserEntity();

            var createdUser =  await _userRepository.CreateAsync( userObject );

            return createdUser.ToUserDto();

        }

        public async Task<UserDto?> UpdateByIdAsync(Guid id, UpdateUserRequestDto updateUserRequestDto)
        {
            var userObject = updateUserRequestDto.ToUpdateUserEntity();

            var updatedUser =  await _userRepository.UpdateByIdAsync(id, userObject);

            if (updatedUser == null)
            {
                return null;
            }

            return updatedUser.ToUserDto();
        }
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _userRepository.DeleteByIdAsync(id);
        }
    }
}
