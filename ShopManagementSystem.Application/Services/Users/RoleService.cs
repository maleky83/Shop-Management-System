using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.Interfaces.Users;
using ShopManagementSystem.Application.Mappings;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Users;

internal sealed class RoleService(
    ApplicationDbContext context
    ) : IRoleService
{
    public async Task<bool> ExistsRoleByIdAsync(int id)
    {
        return await context.Roles.AnyAsync(r => r.Id == id);
    }

    public async Task<RolesCollectionDto> GetAllRolesAsync()
    {
        List<RoleDto> roles = await context
            .Roles
            .Select(RoleQueries.ProjectToDto())
            .ToListAsync();

        var rolesCollectionDto = new RolesCollectionDto
        {
            Data = roles
        };
        return rolesCollectionDto;
    }

}
