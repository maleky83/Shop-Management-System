using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Order;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Shopping;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Entities.Orders;
using ShopManagementSystem.Domain.Enums;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Shopping
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(int userId)
        {
            Cart? cart = await _context.Carts
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

            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<List<OrderViewModel>> GetAllAsync(int userId)
        {
            List<Order> orders = await _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Product)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            return orders.Select(o => new OrderViewModel
            {
                OrderId = o.Id,
                OrderStatus = o.Status,
                TotalPrice = o.TotalPrice,
                UserId = o.UserId,

                OrderDetails = o.OrderDetails.Select(od => new OrderDetailViewModel
                {
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    OrderDetailId = od.Id,
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice,
                }).ToList(),
            }).ToList();
        }

        public async Task<OrderViewModel> GetByIdAsync(int userId, int orderId)
        {
            Order? order = await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Product)
                .FirstOrDefaultAsync(o => o.UserId == userId && o.Id == orderId);

            if (order == null)
            {
                throw new NotFoundException("Order not found");
            }

            return new OrderViewModel
            {
                OrderId = order.Id,
                OrderStatus = order.Status,
                TotalPrice = order.TotalPrice,
                UserId = order.UserId,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailViewModel
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
}
