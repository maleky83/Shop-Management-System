using ShopManagementSystem.Application.DTOs.Account;

namespace ShopManagementSystem.Application.Interfaces.Authentication;

public interface IAccountService
{
    Task RegisterAsync(RegisterDto dto);
    Task<LoginResponseDto> LoginAsync(LoginDto dto);

}
