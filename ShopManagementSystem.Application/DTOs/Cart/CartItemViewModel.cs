namespace ShopManagementSystem.Application.DTOs.Cart;

public record CartItemViewModel
{
    public int CartItemId { get; init; }
    public decimal TotalPrice { get; init; }
    public int ProductId { get; init; }
    public string? ProductName { get; init; }
    public decimal UnitPrice { get; init; }
    public int Quantity { get; init; }
}
