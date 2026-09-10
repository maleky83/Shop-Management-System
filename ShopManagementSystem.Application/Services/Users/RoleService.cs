using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.Interfaces.Users;
using ShopManagementSystem.Domain.Entities.Identity;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Users;

public class RoleService(
    ApplicationDbContext context,
    IMapper mapper
    ) : IRoleService
{
    public async Task<bool> ExistsRoleByIdAsync(int id)
    {
        return await context.Roles.AnyAsync(r => r.Id == id);
    }

    public async Task<List<RoleViewModel>> GetAllRolesAsync()
    {
        List<Role> roles = await context.Roles.ToListAsync();

        return mapper.Map<List<RoleViewModel>>(roles);
    }

}
