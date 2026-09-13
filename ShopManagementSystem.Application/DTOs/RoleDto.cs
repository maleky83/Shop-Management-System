namespace ShopManagementSystem.Application.DTOs;

public record RoleDto
{
    public int RoleId { get; init; }
    public required string Name { get; init; }
}
