using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Application.DTOs.Users;

public record CreateUserViewModel
{
    [Required]
    public required string Name { get; init; }
    [Required]
    public required string Password { get; init; }
    [Required]
    public required int RoleId { get; init; }

}
