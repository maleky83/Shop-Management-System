using ShopManagementSystem.Core.DTOs;
using ShopManagementSystem.Data.Entities;

namespace ShopManagementSystem.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel?> GetUserAsync(string userName);
        Task AddUserAsync(User user);
        Task RegisterAsync(RegisterViewModel model);
    }
}
