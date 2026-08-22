using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.Interfaces.Services;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
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
            if (await _userService.ExistsByNameAsync(model.Name))
                throw new Exception("Uesr is exist");


            await _userService.CreateForRegisterAsync(model);
        }
        public async Task<LoginResponseViewModel> LoginAsync(LoginViewModel model)
        {
            var user = await _userService.GetUserByNameAsync(model.Name);

            if (user is null)
                throw new Exception("Invalid username or password.");

            var passwordResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

            if (passwordResult == PasswordVerificationResult.Failed)
                throw new Exception("Invalid username or password.");

            var token = _tokenService.CreateToken(user);

            return new LoginResponseViewModel()
            {
                Token = token
            };
        }
    }
}
