namespace ShopManagementSystem.Application.DTOs.Order;

public sealed record OrderDetailDto
{
    public required string OrderDetailId { get; init; }
    public required string OrderId { get; init; }
    public required string ProductId { get; init; }
    public decimal UnitPrice { get; init; }
    public int Quantity { get; init; }
}
