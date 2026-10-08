namespace ShopManagementSystem.Application.Users.Dtos;

public record LoginDto
{
    public required string Name { get; init; }

    public required string Password { get; init; }
}
