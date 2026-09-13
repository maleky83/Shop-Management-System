namespace ShopManagementSystem.Application.DTOs.Users;

public sealed record UsersCollectionDto
{
    public required IReadOnlyCollection<UserDto> Data { get; init; }
}

public sealed record UserDto
{
    public int? UserId { get; init; }
    public int RoleId { get; init; }
    public required string PasswordHash { get; init; }
    public required string Name { get; init; }
    public bool IsActive { get; init; }
    public DateTime CreatedAt { get; init; }
}
