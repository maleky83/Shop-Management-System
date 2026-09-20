using ShopManagementSystem.Application.DTOs.Order;
using ShopManagementSystem.Domain.Entities.Orders;

namespace ShopManagementSystem.Application.Mappings.Shopping;

internal static class OrderMappings
{
    public static OrderDto ToDto(this Order order)
    {
        return new OrderDto
        {
            OrderId = order.Id,
            OrderStatus = order.Status,
            TotalPrice = order.TotalPrice,
            UserId = order.UserId,
        };
    }
}
