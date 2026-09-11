namespace ShopManagementSystem.Application.DTOs.Account;

public record LoginResponseViewModel
{
    public string Token { get; init; } = string.Empty;
}
