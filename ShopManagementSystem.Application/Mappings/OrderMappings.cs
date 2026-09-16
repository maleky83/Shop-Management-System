using System.Linq.Expressions;
using ShopManagementSystem.Application.DTOs.Order;
using ShopManagementSystem.Domain.Entities.Orders;

namespace ShopManagementSystem.Application.Mappings;

internal static class OrderMappings
{
    public static OrderDto OrderToDto(this Order order)
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

internal static class OrderQueries
{
    public static Expression<Func<OrderDetail, OrderDetailDto>> ProjectToDto()
    {
        return orderDetail => new OrderDetailDto
        {
            OrderId = orderDetail.OrderId,
            ProductId = orderDetail.ProductId,
            OrderDetailId = orderDetail.Id,
            Quantity = orderDetail.Quantity,
            UnitPrice = orderDetail.UnitPrice,
        };
    }
}
