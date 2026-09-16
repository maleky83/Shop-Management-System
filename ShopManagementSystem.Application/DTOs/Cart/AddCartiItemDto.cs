namespace ShopManagementSystem.Application.DTOs.Cart;

public record AddCartiItemDto
{
    public required string ProductId { get; init; }
    public int Quantity { get; init; }
}
