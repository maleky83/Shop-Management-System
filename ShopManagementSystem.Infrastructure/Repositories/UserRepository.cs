using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Domain.Entities.Identity;
using ShopManagementSystem.Domain.Repositories;
using ShopManagementSystem.Infrastructure.Persistence;

namespace ShopManagementSystem.Infrastructure.Repositories;

internal class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async Task CreateAsync(User user)
    {
        var roleExists = await dbContext.Roles.AnyAsync(r => r.Id == user.RoleId);

        if (!roleExists)
        {
            throw new NotFoundException("Role not found");
        }

        await dbContext.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        User? user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        return user;
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await dbContext
            .Users
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            throw new NotFoundException("User not found");

        dbContext.Remove(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, User entity)
    {
        var user = await GetByIdAsync(id);

        if (user is null)
        {
            throw new NotFoundException("User not found");
        }

        user.PasswordHash = entity.PasswordHash;
        user.Name = entity.Name;
        user.RoleId = entity.RoleId;
        user.IsActive = entity.IsActive;

        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        IEnumerable<User> users = dbContext.Users;

        return users;
    }

    public async Task RegisterAsync(User entity)
    {
        var userExists = await dbContext.Users.AnyAsync(u => u.Id == entity.Id);

        if (userExists)
        {
            throw new NotFoundException("Uesr exists");
        }

        await dbContext.Users.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<User> GetUserByNameAsync(string name)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Name == name);

        if (user is null)
        {
            throw new NotFoundException("user not found");
        }

        return user;
    }
}
