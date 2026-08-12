using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.DTOs.AccountViweModels;
using ShopManagementSystem.Application.Interfaces;
using ShopManagementSystem.Domain.Entities;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly ProgramContext _context;
        private readonly PasswordHasher<User> _passwordHasher;
        public AccountService(ProgramContext context, PasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> IsExistUserByNameAsync(string userName)
        {
            return await _context.Users.AnyAsync(u => u.Name == userName);
        }
        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task RegisterAsync(RegisterViewModel model)
        {
            User user = new User()
            {
                Name = model.Name,
                RegisterDate = DateTime.Now,
                IsAdmin = true
            };
            user.Password = _passwordHasher.HashPassword(user, model.Password);


            await AddUserAsync(user);
        }
        public async Task<UserDetailViewModel?> LoginAsync(LoginViewModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == model.Name);

            if (user == null)
                return null;

            if (_passwordHasher.VerifyHashedPassword(user, user.Password, model.Password) == 0)
                return null;

            return new UserDetailViewModel()
            {
                IsAdmin = user.IsAdmin,
                Name = user.Name,
                UserId = user.Id,
            };
        }
    }
}
