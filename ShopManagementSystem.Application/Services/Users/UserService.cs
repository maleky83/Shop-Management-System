using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.DTOs.Users;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Users;
using ShopManagementSystem.Application.Mappings;
using ShopManagementSystem.Domain.Entities.Identity;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Users;

internal sealed class UserService(
    IPasswordHasher<User> passwordHasher,
    ApplicationDbContext context,
    IRoleService roleService
    ) : IUserService
{
    public async Task<UserDto> CreateAsync(CreateUserDto model)
    {
        var roleExists = await roleService.ExistsRoleByIdAsync(model.RoleId);

        if (!roleExists)
        {
            throw new BadRequestException("Role not found");
        }

        User user = model.ToEntity();

        user.PasswordHash = passwordHasher.HashPassword(user, model.Password);
        await context.AddAsync(user);
        await context.SaveChangesAsync();

        return user.ToDto();
    }

    public async Task DeleteAsync(string id)
    {
        User user = await GetUserByIdAsync(id);

        if (user == null)
            throw new NotFoundException("User not found");

        context.Remove(user);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(string id, UpdateUserDto model)
    {
        User user = await GetUserByIdAsync(id);

        if (user == null)
            throw new NotFoundException("User not found");

        user.UpdateFromDto(model);

        if (!string.IsNullOrEmpty(model.NewPassword))
        {
            user.PasswordHash = passwordHasher.HashPassword(user, model.NewPassword);
        }

        await context.SaveChangesAsync();
    }

    public async Task<UserDto> GetByIdAsync(string id)
    {
        User? user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            throw new NotFoundException("User not found");

        return user.ToDto();
    }

    public async Task<UsersCollectionDto> GetAllAsync()
    {
        List<UserDto> users = await context
            .Users
            .Select(UserQureies.ProjectToDto())
            .ToListAsync();

        var usersCollectionDto = new UsersCollectionDto
        {
            Data = users
        };

        return usersCollectionDto;
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await context.Users.AnyAsync(u => u.Name == name);
    }

    public async Task<UserDto> GetByNameAsync(string name)
    {
        User? user = await context.Users.FirstOrDefaultAsync(u => u.Name == name);

        if (user == null)
            throw new NotFoundException("User not found");

        return user.ToDto();
    }

    public async Task CreateForRegisterAsync(RegisterDto model)
    {
        var userExists = await ExistsByNameAsync(model.Name);

        if (userExists)
            throw new BadRequestException("Uesr exists");

        User user = model.RegisterDtoToEntity();

        user.PasswordHash = passwordHasher.HashPassword(user, model.Password);

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task<User> GetUserByNameAsync(string name)
    {
        User? user = await context.Users.FirstOrDefaultAsync(u => u.Name == name);

        if (user == null)
            throw new NotFoundException("User not found");

        return user;
    }

    public async Task<User> GetUserByIdAsync(string id)
    {
        User? user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        return user;
    }
}
