namespace ShopManagementSystem.Application.DTOs;

public sealed record RolesCollectionDto
{
    public required IReadOnlyCollection<RoleDto> Data { get; init; }
}

public record RoleDto
{
    public int RoleId { get; init; }
    public required string Name { get; init; }
}
