using Microsoft.AspNetCore.Identity;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Authentication;
using ShopManagementSystem.Application.Interfaces.Users;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Services.Authentication;

public class AccountService : IAccountService
{
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;
    public AccountService(
        IPasswordHasher<User> passwordHasher,
        ITokenService tokenService,
        IUserService userService
        )
    {
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
        _userService = userService;
    }

    public async Task RegisterAsync(RegisterViewModel model)
    {
        await _userService.CreateForRegisterAsync(model);
    }

    public async Task<LoginResponseViewModel> LoginAsync(LoginViewModel model)
    {
        User user = await _userService.GetUserByNameAsync(model.Name);

        if (user == null)
            throw new BadRequestException("Invalid username or password.");

        PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

        if (passwordResult == PasswordVerificationResult.Failed)
            throw new BadRequestException("Invalid username or password.");

        var token = _tokenService.CreateToken(user);

        return new LoginResponseViewModel()
        {
            Token = token
        };
    }
}
