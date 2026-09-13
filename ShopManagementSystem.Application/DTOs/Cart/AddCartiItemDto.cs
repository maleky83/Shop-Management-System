namespace ShopManagementSystem.Application.DTOs.Cart;

public record AddCartiItemDto
{
    public int ProductId { get; init; }
    public int Quantity { get; init; }
}
