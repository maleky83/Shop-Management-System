using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces;
using ShopManagementSystem.Domain.Entities.Orders;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Shopping
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _context;
        public PaymentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaymentViewModel> CreatePaymentAsync(int userId, int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.Payments)
                .FirstOrDefaultAsync(o => o.UserId == userId && o.Id == orderId);

            if (order == null)
            {
                throw new NotFoundException("Order not found");
            }

            if (order.Status != OrderStatus.Pending)
            {
                throw new BadRequestException("This order can not be paid");
            }

            var alreadyPaid = await _context.Payments
                .AnyAsync(p => p.OrderId == order.Id && p.Status == PaymentStatus.Paid);

            if (alreadyPaid)
            {
                throw new BadRequestException("This order has already been paid");
            }

            var payment = new Payment
            {
                Amount = order.TotalPrice,
                OrderId = order.Id,
                Status = PaymentStatus.Pending,
                CreatedAt = DateTime.UtcNow,
            };

            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();

            return new PaymentViewModel
            {
                Amount = payment.Amount,
                CreatedAt = payment.CreatedAt,
                OrderId = payment.OrderId,
                PaidAt = payment.PaidAt,
                PaymentId = payment.Id,
                ReferenceId = payment.ReferenceId,
                Status = payment.Status,
            };
        }

        public Task VerifyPaymentAsync(string authority, bool isSuccess)
        {
            throw new NotImplementedException();
        }
    }
}
