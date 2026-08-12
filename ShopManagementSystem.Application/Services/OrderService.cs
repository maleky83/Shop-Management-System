using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.OrderViewModels;
using ShopManagementSystem.Application.Interfaces;
using ShopManagementSystem.Domain.Entities.Orders;
using ShopManagementSystem.Domain.Enums;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly ProgramContext _context;
        public OrderService(ProgramContext context)
        {
            _context = context;
        }

        public async Task AddToOrderAsync(int itemId, int userId)
        {
            var product = await _context.Products.Include(p => p.Item).AsNoTracking().FirstOrDefaultAsync(p => p.ItemId == itemId);
            if (product != null)
            {
                var order = await _context.Orders.FirstOrDefaultAsync(o => o.UserId == userId && !o.IsFinaly);

                if (order != null)
                {
                    var orderDetail = await _context.OrderDetail.FirstOrDefaultAsync(d =>
                    d.OrderId == order.Id &&
                    d.ProductId == product.Id);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        await _context.OrderDetail.AddAsync(new OrderDetail()
                        {
                            OrderId = order.Id,
                            Count = 1,
                            ProductId = product.Id,
                            Price = product.Item.Price
                        });
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    order = new Order()
                    {
                        IsFinaly = false,
                        CreateTime = DateTime.Now,
                        UserId = userId
                    };
                    await _context.Orders.AddAsync(order);
                    await _context.SaveChangesAsync();
                    await _context.OrderDetail.AddAsync(new OrderDetail()
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Price = product.Item.Price,
                        Count = 1
                    });
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task<OrderViewModel?> ShowOrderAsync(int userId)
        {
            var order = await _context.Orders.Where(o => o.UserId == userId && !o.IsFinaly)
                .Select(o => new OrderViewModel()
                {
                    UserId = o.UserId,
                    OrderId = o.Id,
                    IsFinaly = o.IsFinaly,
                    Sum = o.OrderDetails.Sum(od => od.Count * od.Price),
                    OrderDetails = o.OrderDetails.Select(od => new OrderDetailViewModel()
                    {
                        ProductId = od.ProductId,
                        Price = od.Price * od.Count,
                        Count = od.Count,
                        DetailId = od.Id,
                        ProductName = od.Product.Name,
                    }).ToList(),
                }).FirstOrDefaultAsync();

            return order;
        }

        public async Task<OrderStatus> ReduceOrderAsync(int detailId, int userId)
        {
            var orderDetail = await _context.OrderDetail.FindAsync(detailId);

            if (orderDetail == null)
                return OrderStatus.NotFoundOrderDetail;

            if (orderDetail.Count > 1)
            {
                orderDetail.Count -= 1;
                await _context.SaveChangesAsync();
            }
            if (orderDetail.Count == 1)
                return OrderStatus.RemoveOrder;

            return OrderStatus.Succeeded;
        }

        public async Task<OrderStatus> RemoveOrderAsync(int detailId, int userId)
        {
            var orderDetail = await _context.OrderDetail
                .FirstOrDefaultAsync(od => od.Id == detailId && od.Order.UserId == userId);

            if (orderDetail == null)
                return OrderStatus.NotFoundOrderDetail;

            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderDetail.OrderId);

            if (order == null)
                return OrderStatus.NotFoundOrder;

            _context.Remove(orderDetail);
            await _context.SaveChangesAsync();

            var orderDetailCount = await _context.OrderDetail.Where(o => o.OrderId == order.Id).SumAsync(o => o.Count);

            if (orderDetailCount == 0)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();

            return OrderStatus.Succeeded;
        }

        public async Task PaymentAsync(int orderId)
        {
            var order = await _context.Orders.Where(o => o.Id == orderId).FirstOrDefaultAsync();
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
