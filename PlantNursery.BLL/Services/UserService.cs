using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlantNursery.BLL.Interfaces;
using PlantNursery.DAL.Entities;
using PlantNursery.DAL.Interfaces;
using PlantNursery.DAL.Repositories;
using PlantNursery.DTO;
using PlantNursery.DTO.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.BLL.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> PostUser(UserCreateDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto), "User data cannot be null");
            }

            var existingUser = await _userRepository.LoginUser(userDto.Username, HashPassword(userDto.PasswordHash));
            if (existingUser != null)
                throw new InvalidOperationException("User already exists with the provided username.");


            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = HashPassword(userDto.PasswordHash);
            // Use userDto.Password instead of user.Password
            var createdUser = await _userRepository.PostUser(user);
            return _mapper.Map<UserResponseDto>(createdUser);
        }

        public async Task<UserResponseDto?> LoginAsync(string username, string password)
        {
            var hashedPassword = HashPassword(password);
            var user = await _userRepository.LoginUser(username, hashedPassword);
            if (user == null) return null;

            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto?> UpdateUserAsync(int id, UserUpdatedDto dto)
        {
            var updatedUserEntity = _mapper.Map<User>(dto);
            if (!string.IsNullOrEmpty(dto.PasswordHash))
            {
                updatedUserEntity.PasswordHash = HashPassword(dto.PasswordHash);
            }

            var updatedUser = await _userRepository.UpdateUser(id, updatedUserEntity);
            return updatedUser == null ? null : _mapper.Map<UserResponseDto>(updatedUser);
        }

        private string HashPassword(string password)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

    }
}
