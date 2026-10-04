using ShopManagementSystem.Application.DTOs.Order;
using ShopManagementSystem.Application.Interfaces.Shopping;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.Services.Shopping;

public sealed class OrderService(IOrderRepository orderRepository) : IOrderService
{
    public async Task<Guid> CreateAsync(Guid userId)
    {
        var id = await orderRepository.CreateAsync(userId);
        return id;
    }

    public async Task<OrdersCollectionDto> GetAllAsync(Guid userId)
    {
        var orders = await orderRepository.GetAllAsync(userId);

        var orderDtos = orders
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.CreatedAt)
            .Select(o => new OrderDto
            {
                OrderId = o.Id,
                OrderStatus = o.Status,
                TotalPrice = o.TotalPrice,
                UserId = o.UserId,
                OrderDetails = o.OrderDetails.Select(od => new OrderDetailDto
                {
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    OrderDetailId = od.Id,
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice,
                }).ToList()
            }).ToList();

        var ordersCollectionDto = new OrdersCollectionDto
        {
            Data = orderDtos
        };
        return ordersCollectionDto;
    }

    public async Task<OrderDto> GetByIdAsync(Guid userId, Guid orderId)
    {
        var order = await orderRepository.GetByIdAsync(userId, orderId);

        return new OrderDto
        {
            OrderId = order.Id,
            OrderStatus = order.Status,
            TotalPrice = order.TotalPrice,
            UserId = order.UserId,
            OrderDetails = order.OrderDetails.Select(od => new OrderDetailDto
            {
                OrderId = od.OrderId,
                UnitPrice = od.UnitPrice,
                Quantity = od.Quantity,
                OrderDetailId = od.Id,
                ProductId = od.ProductId,
            }).ToList(),
        };
    }
}
