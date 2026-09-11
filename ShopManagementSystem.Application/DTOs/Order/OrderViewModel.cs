using ShopManagementSystem.Domain.Enums;

namespace ShopManagementSystem.Application.DTOs.Order;

public record OrderViewModel
{
    public int OrderId { get; init; }
    public int UserId { get; init; }
    public decimal TotalPrice { get; init; }
    public OrderStatus OrderStatus { get; init; }
    public List<OrderDetailViewModel>? OrderDetails { get; init; }
}
