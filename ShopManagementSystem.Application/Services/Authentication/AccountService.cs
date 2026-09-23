using Microsoft.AspNetCore.Identity;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Authentication;
using ShopManagementSystem.Application.Interfaces.Users;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Services.Authentication;

internal sealed class AccountService(
    IPasswordHasher<User> passwordHasher,
    ITokenService tokenService,
    IUserService userService
    ) : IAccountService
{
    public async Task RegisterAsync(RegisterDto model)
    {
        await userService.CreateForRegisterAsync(model);
    }

    public async Task<LoginResponseDto> LoginAsync(LoginDto model)
    {
        User user = await userService.GetUserByNameAsync(model.Name);

        if (user == null)
            throw new BadRequestException("Invalid username or password.");

        PasswordVerificationResult passwordResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

        if (passwordResult == PasswordVerificationResult.Failed)
            throw new BadRequestException("Invalid username or password.");

        var token = tokenService.CreateToken(user);

        return new LoginResponseDto()
        {
            Token = token
        };
    }
}
