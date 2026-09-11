namespace ShopManagementSystem.Application.DTOs;

public record ErrorResponse
{
    public int StatusCode { get; init; }
    public required string Message { get; init; }
}
