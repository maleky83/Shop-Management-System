using ShopManagementSystem.Domain.Enums;

namespace ShopManagementSystem.Application.DTOs.Order;

public record CreateOrderViewModel
{
    public int UserId { get; init; }
    public OrderStatus Status { get; init; } = OrderStatus.Pending;
    public decimal TotalPrice { get; init; }
}
