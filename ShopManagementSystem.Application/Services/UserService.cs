using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.DTOs.Admin;
using ShopManagementSystem.Application.Interfaces.Services;
using ShopManagementSystem.Domain.Entities.Identity;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ProgramContext _context;
        private readonly IMapper _mapper;
        public UserService(
            IPasswordHasher<User> passwordHasher,
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
            user.CreatedAt = DateTime.UtcNow;
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

        public async Task UpdateAsync(int id, UpdateUserViewModel model)
        {
            var user = await GetUserByIdAsync(id);

            if (user is null)
                throw new Exception("no users");

            _mapper.Map(model, user);

            if (!string.IsNullOrEmpty(model.NewPassword))
            {
                user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<UserViewModel> GetByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
                throw new Exception("No Users");

            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<List<UserViewModel>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();

            return _mapper.Map<List<UserViewModel>>(users);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Users.AnyAsync(u => u.Name == name);
        }

        public async Task<UserViewModel> GetByNameAsync(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == name);

            if (user is null)
                throw new Exception("No users");

            return _mapper.Map<UserViewModel>(user);
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

        public async Task<User> GetUserByNameAsync(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == name);

            if (user is null)
                throw new Exception("No users");

            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
            {
                throw new Exception("No users");
            }

            return user;
        }
    }
}
