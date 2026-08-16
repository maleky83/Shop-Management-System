using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.DTOs.AccountViweModels;

namespace ShopManagementSystem.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterViewModel model);
        Task<LoginResponseViewModel> LoginAsync(LoginViewModel model);

    }
}
