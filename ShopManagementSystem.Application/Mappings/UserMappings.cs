using System.Linq.Expressions;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.DTOs.Users;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Mappings;

internal static class UsertMappings
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Name = user.Name,
            PasswordHash = user.PasswordHash,
            CreatedAt = user.CreatedAt,
            IsActive = user.IsActive,
            RoleId = user.RoleId,
            UserId = user.Id,
        };
    }

    public static User ToEntity(this CreateUserDto dto)
    {
        return new User
        {
            Name = dto.Name,
            RoleId = dto.RoleId,
            Id = $"u_{Guid.CreateVersion7()}",
            CreatedAt = DateTime.UtcNow,
        };
    }

    public static void UpdateFromDto(this User user, UpdateUserDto dto)
    {
        user.IsActive = dto.IsActive;
        user.Name = dto.Name;
        user.RoleId = dto.RoleId;
    }

    public static User RegisterDtoToEntity(this RegisterDto dto)
    {
        return new User
        {
            Id = $"u_{Guid.CreateVersion7()}",
            Name = dto.Name,
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
        };
    }
}

internal static class UserQureies
{
    public static Expression<Func<User, UserDto>> ProjectToDto()
    {
        return userDto => new UserDto
        {
            Name = userDto.Name,
            PasswordHash = userDto.PasswordHash,
            CreatedAt = userDto.CreatedAt,
            IsActive = userDto.IsActive,
            RoleId = userDto.RoleId,
            UserId = userDto.Id,
        };
    }
}
