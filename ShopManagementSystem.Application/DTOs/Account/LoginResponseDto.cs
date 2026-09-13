namespace ShopManagementSystem.Application.DTOs.Account;

public record LoginResponseDto
{
    public string Token { get; init; } = string.Empty;
}
