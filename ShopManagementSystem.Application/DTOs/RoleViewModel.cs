namespace ShopManagementSystem.Application.DTOs;

public record RoleViewModel
{
    public int RoleId { get; init; }
    public required string Name { get; init; }
}
