namespace ShopManagementSystem.Application.Users.Dtos;

public record LoginResponseDto
{
    public string Token { get; init; } = string.Empty;
}
