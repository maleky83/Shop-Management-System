using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Domain.Entities;

namespace ShopManagementSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel?> GetUserAsync(string userName);
        Task AddUserAsync(User user);
        Task RegisterAsync(RegisterViewModel model);
    }
}
