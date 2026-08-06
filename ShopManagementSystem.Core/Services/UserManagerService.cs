using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Core.DTOs;
using ShopManagementSystem.Core.Services.Interfaces;
using ShopManagementSystem.Data.Context;
using ShopManagementSystem.Data.Entities;

namespace ShopManagementSystem.Core.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly ProgramContext _context;
        private readonly PasswordHasher<User> _passwordHasher;
        public UserManagerService(ProgramContext context, PasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task CreateAsync(UserViewModel model)
        {
            User user = new User()
            {
                Name = model.Name,
                IsAdmin = model.IsAdmin,
                RegisterDate = DateTime.Now,
            };

            user.Password = _passwordHasher.HashPassword(user, model.Password);

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId)
        {
            User user = await _context.Users.FirstAsync(u => u.Id== userId);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserViewModel> DetailAsync(int userId)
        {
            return await GetUserById(userId);
        }

        public async Task EditAsync(EditUserViweModel model)
        {
            User user = await _context.Users.FirstAsync(u => u.Name == model.Name);
            user.Name = model.Name;
            user.IsAdmin = model.IsAdmin;

            if (!string.IsNullOrEmpty(model.Password))
            {
                user.Password = _passwordHasher.HashPassword(user, model.Password);
            }

            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserViewModel> GetUserById(int userId)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserViewModel()
                {
                    IsAdmin = u.IsAdmin,
                    Name = u.Name,
                    Password = u.Password
                }).FirstAsync();
        }

        public async Task<EditUserViweModel> GetUserForEditAsync(int userId)
        {
            return await _context.Users
                .Where(u => u.Id== userId)
                .Select(u => new EditUserViweModel()
                {
                    Name = u.Name,
                    UserId= u.Id,
                    IsAdmin = u.IsAdmin,
                    Password = u.Password
                }).FirstAsync();
        }

        public async Task<List<UserViewModel>> GetUsers()
        {
            return await _context.Users.Select(u => new UserViewModel()
            {
                UserId= u.Id,
                IsAdmin = u.IsAdmin,
                Name = u.Name,
                Password = u.Password,
            }).AsNoTracking().ToListAsync();
        }
    }
}
