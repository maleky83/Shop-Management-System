namespace ShopManagementSystem.Application.DTOs.Users;

public record UpdateUserDto
{
    public required string Name { get; init; }
    public string? NewPassword { get; init; }
    public int RoleId { get; init; }
    public bool IsActive { get; init; }
}
