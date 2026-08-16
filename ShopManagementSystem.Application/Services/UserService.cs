using Microsoft.AspNetCore.Identity;
using ShopManagementSystem.Application.DTOs.Admin;
using ShopManagementSystem.Application.Interfaces.Repositories;
using ShopManagementSystem.Application.Interfaces.Services;
using ShopManagementSystem.Domain.Entities.User;

namespace ShopManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly IUserRepository _userRepository;
        public UserService(PasswordHasher<User> passwordHasher, IUserRepository userRepository)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public async Task CreateAsync(CreateUserViewModel model)
        {
            User user = new User()
            {
                Name = model.Name,
                CreatedAt = DateTime.Now,
                IsActive = true,
                UpdatedAt = DateTime.Now,
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);

            await _userRepository.CreateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new Exception("No Users");

            await _userRepository.DeleteAsync(user);
        }

        public async Task UpdateAsync(EditUserViewModel model)
        {
            User? user = await _userRepository.GetByIdAsync(model.UserId);

            if (user == null)
                throw new Exception("no users");

            user.Name = model.Name;

            if (!string.IsNullOrEmpty(model.NewPassword))
            {
                user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
            }

            await _userRepository.UpdateAsync(user);
        }


        //public async Task<EditUserViewModel> GetUserForUpdateAsync(int? userId)
        //{
        //    return await _context.Users
        //        .Where(u => u.Id == userId)
        //        .Select(u => new EditUserViewModel()
        //        {
        //            Name = u.Name,
        //            UserId = u.Id,
        //            IsAdmin = u.IsAdmin,
        //        }).FirstAsync();
        //}

        public async Task<List<UserListViewModel>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(u => new UserListViewModel
            {
                Name = u.Name,
                UserId = u.Id,
            }).ToList();
        }

        //public async Task<UserDetailViewModel?> UserDetailAsync(int? userId)
        //{
        //    return await _context.Users.Where(u => u.Id == userId)
        //         .Select(u => new UserDetailViewModel()
        //         {
        //             IsAdmin = u.IsAdmin,
        //             Name = u.Name,
        //             Password = u.Password,
        //         }).FirstOrDefaultAsync();
        //}
    }
}
