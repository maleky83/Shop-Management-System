using ShopManagementSystem.Application.DTOs.Users;

namespace ShopManagementSystem.Application.Interfaces.Users;

public interface IUserService
{
    Task<UsersCollectionDto> GetAllAsync();
    Task<UserDto> GetByIdAsync(Guid id);
    Task UpdateAsync(Guid id, UpdateUserDto updateUserDto);
    Task DeleteAsync(Guid id);
    Task<UserDto> CreateAsync(CreateUserDto createUserDto);
}
