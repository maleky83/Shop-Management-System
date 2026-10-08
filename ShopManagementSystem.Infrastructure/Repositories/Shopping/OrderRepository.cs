using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Entities.Orders;
using ShopManagementSystem.Domain.Enums;
using ShopManagementSystem.Domain.Repositories.Shopping;
using ShopManagementSystem.Infrastructure.Persistence;

namespace ShopManagementSystem.Infrastructure.Repositories.Shopping;

internal class OrderRepository(ApplicationDbContext dbContext) : IOrderRepository
{
    public async Task<Guid> CreateAsync(Guid userId)
    {
        Cart? cart = await dbContext.Carts
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

        await dbContext.Orders.AddAsync(order);
        await dbContext.SaveChangesAsync();
        return order.Id;
    }

    public async Task<IEnumerable<Order>> GetAllAsync(Guid userId)
    {
        List<Order> orders = await dbContext.Orders
            .Where(o => o.UserId == userId)
            .ToListAsync();

        return orders;
    }

    public async Task<Order> GetByIdAsync(Guid userId, Guid orderId)
    {
        Order? order = await dbContext.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(o => o.Product)
            .FirstOrDefaultAsync(o => o.UserId == userId && o.Id == orderId);

        if (order == null)
        {
            throw new NotFoundException("Order not found");
        }

        return order;
    }
}
