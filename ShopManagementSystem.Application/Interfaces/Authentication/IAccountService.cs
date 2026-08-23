using ShopManagementSystem.Application.DTOs.Account;

namespace ShopManagementSystem.Application.Interfaces.Authentication
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterViewModel model);
        Task<LoginResponseViewModel> LoginAsync(LoginViewModel model);

    }
}
