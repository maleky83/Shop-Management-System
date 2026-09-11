namespace ShopManagementSystem.Application.DTOs.Users;

public record UserViewModel
{
    public int? UserId { get; init; }
    public int RoleId { get; init; }
    public required string PasswordHash { get; init; }
    public required string Name { get; init; }
    public bool IsActive { get; init; }
    public DateTime CreatedAt { get; init; }
}
