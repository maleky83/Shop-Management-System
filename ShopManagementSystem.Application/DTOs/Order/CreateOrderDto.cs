using ShopManagementSystem.Domain.Enums;

namespace ShopManagementSystem.Application.DTOs.Order;

public record CreateOrderDto
{
    public int UserId { get; init; }
    public OrderStatus Status { get; init; } = OrderStatus.Pending;
    public decimal TotalPrice { get; init; }
}
