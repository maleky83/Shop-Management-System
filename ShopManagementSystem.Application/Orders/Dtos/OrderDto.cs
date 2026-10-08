using ShopManagementSystem.Domain.Enums;

namespace ShopManagementSystem.Application.Orders.Dtos;

public sealed record OrdersCollectionDto
{
    public required IReadOnlyCollection<OrderDto> Data { get; init; }
}

public record OrderDto
{
    public required Guid OrderId { get; init; }
    public required Guid UserId { get; init; }
    public decimal TotalPrice { get; init; }
    public OrderStatus OrderStatus { get; init; }
    public List<OrderDetailDto> OrderDetails { get; init; } = default!;
}
