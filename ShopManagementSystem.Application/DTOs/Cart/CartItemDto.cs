namespace ShopManagementSystem.Application.DTOs.Cart;

public record CartItemDto
{
    public required string CartItemId { get; init; }
    public decimal TotalPrice { get; init; }
    public required string ProductId { get; init; }
    public string? ProductName { get; init; }
    public decimal UnitPrice { get; init; }
    public int Quantity { get; init; }
}
