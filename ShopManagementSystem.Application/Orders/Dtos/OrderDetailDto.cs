namespace ShopManagementSystem.Application.Orders.Dtos;

public sealed record OrderDetailDto
{
    public required Guid OrderDetailId { get; init; }
    public required Guid OrderId { get; init; }
    public required Guid ProductId { get; init; }
    public decimal UnitPrice { get; init; }
    public int Quantity { get; init; }
}
