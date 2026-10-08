using ShopManagementSystem.Application.Users.Dtos;

namespace ShopManagementSystem.Application.Interfaces.Authentication;

public interface IAccountService
{
    Task RegisterAsync(RegisterDto dto);
    Task<LoginResponseDto> LoginAsync(LoginDto dto);

}
