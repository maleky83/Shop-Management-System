using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Order;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Shopping;
using ShopManagementSystem.Application.Mappings.Shopping;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Entities.Orders;
using ShopManagementSystem.Domain.Enums;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Shopping;

public class OrderService(ApplicationDbContext context) : IOrderService
{
    public async Task<OrderDto> CreateAsync(string userId)
    {
        Cart? cart = await context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(c => c.Product)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null || !cart.CartItems.Any())
        {
            throw new NotFoundException("Cart is empty");
        }

        var order = new Order
        {
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            Status = OrderStatus.Pending,
        };

        foreach (CartItem cartItem in cart.CartItems)
        {
            var orderDetail = new OrderDetail
            {
                UnitPrice = cartItem.Product.Price,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                TotalPrice = cartItem.Quantity * cartItem.Product.Price,
            };

            order.OrderDetails.Add(orderDetail);
        }

        order.TotalPrice = order.OrderDetails.Sum(od => od.TotalPrice);

        await context.Orders.AddAsync(order);

        await context.SaveChangesAsync();

        return order.ToDto();
    }

    public async Task<OrdersCollectionDto> GetAllAsync(string userId)
    {
        List<OrderDto> orders = await context.Orders
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
            }).ToListAsync();

        var ordersCollectionDto = new OrdersCollectionDto
        {
            Data = orders
        };
        return ordersCollectionDto;
    }

    public async Task<OrderDto> GetByIdAsync(string userId, string orderId)
    {
        Order? order = await context.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(o => o.Product)
            .FirstOrDefaultAsync(o => o.UserId == userId && o.Id == orderId);

        if (order == null)
        {
            throw new NotFoundException("Order not found");
        }

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
