using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.DTOs.Users;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Interfaces.Users;

public interface IUserService
{
    public Task<bool> ExistsByNameAsync(string name);
    public Task<UserDto> GetByIdAsync(string id);
    Task<UsersCollectionDto> GetAllAsync();
    public Task<UserDto> GetByNameAsync(string name);
    public Task<User> GetUserByIdAsync(string id);
    public Task<User> GetUserByNameAsync(string name);
    Task<UserDto> CreateAsync(CreateUserDto model);
    Task CreateForRegisterAsync(RegisterDto model);
    Task DeleteAsync(string id);
    Task UpdateAsync(string id, UpdateUserDto model);
}
