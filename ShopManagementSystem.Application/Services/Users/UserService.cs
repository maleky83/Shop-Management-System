using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.DTOs.Users;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Users;
using ShopManagementSystem.Domain.Entities.Identity;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Users;

public class UserService(
    IPasswordHasher<User> passwordHasher,
    ApplicationDbContext context,
    IMapper mapper,
    IRoleService roleService
    ) : IUserService
{
    public async Task CreateAsync(CreateUserViewModel model)
    {
        User user = mapper.Map<User>(model);

        var roleExists = await roleService.ExistsRoleByIdAsync(model.RoleId);

        if (!roleExists)
        {
            throw new BadRequestException("Role not found");
        }

        user.PasswordHash = passwordHasher.HashPassword(user, model.Password);
        user.CreatedAt = DateTime.UtcNow;
        await context.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        User user = await GetUserByIdAsync(id);

        if (user == null)
            throw new NotFoundException("User not found");

        context.Remove(user);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, UpdateUserViewModel model)
    {
        User user = await GetUserByIdAsync(id);

        if (user == null)
            throw new NotFoundException("User not found");

        mapper.Map(model, user);

        if (!string.IsNullOrEmpty(model.NewPassword))
        {
            user.PasswordHash = passwordHasher.HashPassword(user, model.NewPassword);
        }

        await context.SaveChangesAsync();
    }

    public async Task<UserViewModel> GetByIdAsync(int id)
    {
        User? user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            throw new NotFoundException("User not found");

        return mapper.Map<UserViewModel>(user);
    }

    public async Task<List<UserViewModel>> GetAllAsync()
    {
        List<User> users = await context.Users.ToListAsync();

        return mapper.Map<List<UserViewModel>>(users);
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await context.Users.AnyAsync(u => u.Name == name);
    }

    public async Task<UserViewModel> GetByNameAsync(string name)
    {
        User? user = await context.Users.FirstOrDefaultAsync(u => u.Name == name);

        if (user == null)
            throw new NotFoundException("User not found");

        return mapper.Map<UserViewModel>(user);
    }

    public async Task CreateForRegisterAsync(RegisterViewModel model)
    {
        var userExists = await ExistsByNameAsync(model.Name);

        if (userExists)
            throw new BadRequestException("Uesr exists");

        User user = mapper.Map<User>(model);

        user.CreatedAt = DateTime.UtcNow;
        user.IsActive = true;

        user.PasswordHash = passwordHasher.HashPassword(user, model.Password);

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task<UpdateUserViewModel> GetByIdForUpdateAsync(int id)
    {
        User? user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

        return mapper.Map<UpdateUserViewModel>(user);
    }


    public async Task<User> GetUserByNameAsync(string name)
    {
        User? user = await context.Users.FirstOrDefaultAsync(u => u.Name == name);

        if (user == null)
            throw new NotFoundException("User not found");

        return user;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        User? user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        return user;
    }
}
