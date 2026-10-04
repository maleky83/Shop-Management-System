namespace ShopManagementSystem.Application.DTOs.Cart;

public record AddCartiItemDto
{
    public required Guid ProductId { get; init; }
    public required int Quantity { get; init; }
}
