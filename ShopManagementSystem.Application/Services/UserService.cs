using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.DTOs.AccountViweModels;
using ShopManagementSystem.Application.DTOs.Admin;
using ShopManagementSystem.Application.Interfaces.Services;
using ShopManagementSystem.Domain.Entities.User;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly ProgramContext _context;
        private readonly IMapper _mapper;
        public UserService(
            PasswordHasher<User> passwordHasher,
            ProgramContext context,
            IMapper mapper
            )
        {
            _passwordHasher = passwordHasher;
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateUserViewModel model)
        {
            var user = _mapper.Map<User>(model);
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);

            if (user == null)
                throw new Exception("No Users");

            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateUserViewModel model)
        {
            var user = await GetByIdAsync(model.UserId);

            if (user is null)
                throw new Exception("no users");

            user.Name = model.Name;
            user.IsActive = model.IsActive;
            user.RoleId = model.RoleId;

            if (!string.IsNullOrEmpty(model.NewPassword))
            {
                user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
            }

            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
                throw new Exception("No Users");

            return user;
        }


        //public async Task<EditUserViewModel> GetUserForUpdateAsync(int? userId)
        //{
        //    return await _context.Users
        //        .Where(u => u.Id == userId)
        //        .Select(u => new EditUserViewModel()
        //        {
        //            Name = u.Name,
        //            UserId = u.Id,
        //            IsActive = u.IsActive,
        //        }).FirstAsync();
        //}

        public async Task<List<UserViewModel>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();

            return _mapper.Map<List<UserViewModel>>(users);
        }

        //public async Task<UserDetailViewModel?> UserDetailAsync(int? userId)
        //{
        //    return await _context.Users.Where(u => u.Id == userId)
        //         .Select(u => new UserDetailViewModel()
        //         {
        //             IsActive = u.IsActive,
        //             Name = u.Name,
        //             Password = u.Password,
        //         }).FirstOrDefaultAsync();
        //}

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Users.AnyAsync(u => u.Name == name);
        }

        public async Task<User?> GetByNameAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task CreateForRegisterAsync(RegisterViewModel model)
        {

            var user = _mapper.Map<User>(model);

            user.Name = model.Name;
            user.CreatedAt = DateTime.Now;
            user.IsActive = true;

            user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UpdateUserViewModel> GetByIdForUpdateAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return _mapper.Map<UpdateUserViewModel>(user);
        }

        public async Task<List<RoleViewModel>> GetAllRolesAsync()
        {
            var roles = await _context.Roles.ToListAsync();

            return _mapper.Map<List<RoleViewModel>>(roles);
        }
    }
}
