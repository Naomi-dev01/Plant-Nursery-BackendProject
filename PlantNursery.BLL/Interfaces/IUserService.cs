using PlantNursery.DAL.Entities;
using PlantNursery.DTO;
using PlantNursery.DTO.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> PostUser(UserCreateDto userDto);
        Task<UserResponseDto?> LoginAsync(string username, string password);
        Task<UserResponseDto?> UpdateUserAsync(int id, UserUpdatedDto dto);

        // Task<UserCreateDto> PostUser(UserCreateDto user);
    }
}
