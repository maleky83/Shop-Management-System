namespace ShopManagementSystem.Application.DTOs.Order;

public record OrderDetailViewModel
{
    public int OrderDetailId { get; init; }
    public int OrderId { get; init; }
    public int ProductId { get; init; }
    public decimal UnitPrice { get; init; }
    public int Quantity { get; init; }
}
