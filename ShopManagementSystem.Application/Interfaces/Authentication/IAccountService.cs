using ShopManagementSystem.Application.DTOs.Account;

namespace ShopManagementSystem.Application.Interfaces.Authentication;

public interface IAccountService
{
    Task RegisterAsync(RegisterDto model);
    Task<LoginResponseDto> LoginAsync(LoginDto model);

}
