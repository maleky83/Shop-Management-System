using ShopManagementSystem.Domain.Enums;

namespace ShopManagementSystem.Application.DTOs.Order;

public class OrderViewModel
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public List<OrderDetailViewModel>? OrderDetails { get; set; }
}
