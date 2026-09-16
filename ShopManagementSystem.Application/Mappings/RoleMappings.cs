using System.Linq.Expressions;
using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Mappings;

internal static class RoleQueries
{
    public static Expression<Func<Role, RoleDto>> ProjectToDto()
    {
        return roleDto => new RoleDto
        {
            Name = roleDto.Name,
            RoleId = roleDto.Id
        };
    }
}
