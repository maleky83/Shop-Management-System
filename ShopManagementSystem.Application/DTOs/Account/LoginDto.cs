namespace ShopManagementSystem.Application.DTOs.Account;

public record LoginDto
{
    public required string Name { get; init; }

    public required string Password { get; init; }
}
