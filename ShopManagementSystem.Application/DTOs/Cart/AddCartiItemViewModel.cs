namespace ShopManagementSystem.Application.DTOs.Cart;

public record AddCartiItemViewModel
{
    public int ProductId { get; init; }
    public int Quantity { get; init; }
}
