using ShopManagementSystem.Application.DTOs.Users;
using ShopManagementSystem.Application.Users.Dtos;

namespace ShopManagementSystem.Application.Interfaces.Users;

public interface IUserService
{
    Task<UsersCollectionDto> GetAllAsync();
    Task<UserDto> GetByIdAsync(Guid id);
    Task UpdateAsync(Guid id, UpdateUserDto updateUserDto);
    Task DeleteAsync(Guid id);
    Task<UserDto> CreateAsync(CreateUserDto createUserDto);
}
