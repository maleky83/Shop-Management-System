using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.DTOs.AccountViweModels;
using ShopManagementSystem.Domain.Entities;

namespace ShopManagementSystem.Application.Interfaces
{
    public interface IAccountService
    {
        public Task<bool> IsExistUserByNameAsync(string userName);
        Task AddUserAsync(User user);
        Task RegisterAsync(RegisterViewModel model);
        public Task<UserDetailViewModel?> LoginAsync(LoginViewModel model);
    }
}
