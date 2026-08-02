using ShopManagementSystem.Core.DTOs;
using ShopManagementSystem.Data.Entities;

namespace ShopManagementSystem.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserAsync(string name);
        Task AddUserAsync(User user);
        Task RegisterAsync(RegisterViewModel model);
        Task<User?> LoginAsync(LoginViewModel model);
    }
}
