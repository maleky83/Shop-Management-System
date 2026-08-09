using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.Interfaces;
using ShopManagementSystem.Infrastructure.Context;
using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Domain.Entities;

namespace ShopManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ProgramContext _context;
        private readonly PasswordHasher<User> _passwordHasher;
        public UserService(ProgramContext context, PasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserViewModel?> GetUserAsync(string userName)
        {
            return await _context.Users
                .Select(u => new UserViewModel()
                {
                    Name = u.Name,
                    UserId= u.Id,
                    IsAdmin = u.IsAdmin,
                    Password = u.Password,
                    Orders = u.Orders,
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Name == userName);
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
    }
}
