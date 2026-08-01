using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Program.Core.DTOs;
using Program.Core.Services.Interfaces;
using Program.Data.Context;
using Program.Data.Entities;


namespace Program.Core.Services
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

        public async Task<User?> GetUserAsync(string name)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Name == name);
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
        public async Task<User?> LoginAsync(LoginViewModel model)
        {
            User? user = await GetUserAsync(model.Name);

            return user;
        }
    }
}
