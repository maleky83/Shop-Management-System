using Microsoft.AspNetCore.Identity;
using ShopManagementSystem.Api.Exceptions;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.Interfaces;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Services
{
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
            var user = await _userService.GetUserByNameAsync(model.Name);

            if (user is null)
                throw new BadRequestException("Invalid username or password.");

            var passwordResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

            if (passwordResult == PasswordVerificationResult.Failed)
                throw new BadRequestException("Invalid username or password.");

            var token = _tokenService.CreateToken(user);

            return new LoginResponseViewModel()
            {
                Token = token
            };
        }
    }
}
