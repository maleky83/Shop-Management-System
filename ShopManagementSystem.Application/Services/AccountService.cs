using Microsoft.AspNetCore.Identity;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.DTOs.AccountViweModels;
using ShopManagementSystem.Application.Interfaces.Repositories;
using ShopManagementSystem.Application.Interfaces.Services;
using ShopManagementSystem.Domain.Entities.User;

namespace ShopManagementSystem.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly ITokenService _tokenService;
        public AccountService(
            IUserRepository userRepository,
            PasswordHasher<User> passwordHasher,
            ITokenService tokenService
            )
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task RegisterAsync(RegisterViewModel model)
        {
            var userExists = await _userRepository.ExistsByNameAsync(model.Name);

            if (userExists)
                throw new Exception("Uesr is exist");

            User user = new User()
            {
                Name = model.Name,
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);


            await _userRepository.CreateAsync(user);
        }
        public async Task<LoginResponseViewModel> LoginAsync(LoginViewModel model)
        {
            var user = await _userRepository.GetByNameAsync(model.Name);

            if (user == null)
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
