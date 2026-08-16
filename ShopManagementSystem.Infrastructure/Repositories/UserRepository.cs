using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.Interfaces.Repositories;
using ShopManagementSystem.Domain.Entities.User;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ProgramContext _context;
        public UserRepository(ProgramContext context)
        {
            _context = context;
        }
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Users.AnyAsync(u => u.Name == name);
        }

        public async Task CreateAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByNameAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
        }
    }
}
