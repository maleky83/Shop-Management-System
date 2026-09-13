namespace ShopManagementSystem.Application.DTOs.Users;

public record UserDetailDto
{
    public int? UserId { get; init; }
    public string? Name { get; init; }
    public string? Password { get; init; }
    public bool IsActive { get; init; }
}
