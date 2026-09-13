using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.DTOs.Users;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Interfaces.Users;

public interface IUserService
{
    public Task<bool> ExistsByNameAsync(string name);
    public Task<UserDto> GetByIdAsync(int id);
    Task<List<UserDto>> GetAllAsync();
    public Task<UserDto> GetByNameAsync(string name);
    public Task<User> GetUserByIdAsync(int id);
    public Task<UpdateUserDto> GetByIdForUpdateAsync(int id);
    public Task<User> GetUserByNameAsync(string name);
    Task CreateAsync(CreateUserDto model);
    Task CreateForRegisterAsync(RegisterDto model);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, UpdateUserDto model);
}
