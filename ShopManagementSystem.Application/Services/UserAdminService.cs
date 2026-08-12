using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Admin;
using ShopManagementSystem.Application.Interfaces;
using ShopManagementSystem.Domain.Entities;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services
{
    public class UserAdminService : IUserAdminService
    {
        private readonly ProgramContext _context;
        private readonly PasswordHasher<User> _passwordHasher;
        public UserAdminService(ProgramContext context, PasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task CreateAsync(CreateUserViewModel model)
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
            User user = await _context.Users.FirstAsync(u => u.Id == userId);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(EditUserViewModel model)
        {
            User user = await _context.Users.FirstAsync(u => u.Id == model.UserId);
            user.Name = model.Name;
            user.IsAdmin = model.IsAdmin;

            if (!string.IsNullOrEmpty(model.NewPassword))
            {
                user.Password = _passwordHasher.HashPassword(user, model.NewPassword);
            }

            _context.Update(user);
            await _context.SaveChangesAsync();
        }


        public async Task<EditUserViewModel> GetUserForEditAsync(int? userId)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => new EditUserViewModel()
                {
                    Name = u.Name,
                    UserId = u.Id,
                    IsAdmin = u.IsAdmin,
                }).FirstAsync();
        }

        public async Task<List<UserListViewModel>> GetUsersAsync()
        {
            return await _context.Users.Select(u => new UserListViewModel()
            {
                IsAdmin = u.IsAdmin,
                Name = u.Name,
                UserId = u.Id,
                RegisterDate = u.RegisterDate,
            }).AsNoTracking().ToListAsync();
        }

        public async Task<UserDetailViewModel?> UserDetailAsync(int? userId)
        {
            return await _context.Users.Where(u => u.Id == userId)
                 .Select(u => new UserDetailViewModel()
                 {
                     IsAdmin = u.IsAdmin,
                     Name = u.Name,
                     Password = u.Password,
                 }).FirstOrDefaultAsync();
        }
    }
}
