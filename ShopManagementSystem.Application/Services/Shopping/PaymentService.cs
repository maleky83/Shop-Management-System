using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Entities.Orders;
using ShopManagementSystem.Domain.Enums;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Shopping;

public class PaymentService(ApplicationDbContext context) : IPaymentService
{
    public async Task<PaymentViewModel> CreatePaymentAsync(
        int userId,
        int orderId)
    {
        Order? order = await context.Orders
            .FirstOrDefaultAsync(o =>
                o.Id == orderId &&
                o.UserId == userId);

        if (order == null)
        {
            throw new NotFoundException("Order not found");
        }

        if (order.Status != OrderStatus.Pending)
        {
            throw new BadRequestException(
                "This order can not be paid");
        }

        Payment? paidPayment = await context.Payments
            .FirstOrDefaultAsync(p =>
                p.OrderId == orderId &&
                p.Status == PaymentStatus.Paid);

        if (paidPayment != null)
        {
            throw new BadRequestException(
                "This order has already been paid");
        }

        Payment? pendingPayment = await context.Payments
            .FirstOrDefaultAsync(p =>
                p.OrderId == orderId &&
                p.Status == PaymentStatus.Pending);

        if (pendingPayment != null)
        {
            return MapToViewModel(pendingPayment);
        }

        var payment = new Payment
        {
            OrderId = order.Id,
            Amount = order.TotalPrice,
            Status = PaymentStatus.Pending,
            CreatedAt = DateTime.UtcNow,

            Authority = Guid.NewGuid().ToString("N")
        };

        await context.Payments.AddAsync(payment);
        await context.SaveChangesAsync();

        return MapToViewModel(payment);
    }

    public async Task VerifyPaymentAsync(string authority)
    {
        if (string.IsNullOrWhiteSpace(authority))
        {
            throw new BadRequestException(
                "Authority is required");
        }

        Payment? payment = await context.Payments
            .Include(p => p.Order)
            .FirstOrDefaultAsync(p =>
                p.Authority == authority);

        if (payment == null)
        {
            throw new NotFoundException(
                "Payment not found");
        }

        if (payment.Status == PaymentStatus.Paid)
        {
            throw new BadRequestException(
                "Payment has already been paid");
        }

        // ==========================================
        // Mock Payment
        // ==========================================

        var isVerified = true;

        if (!isVerified)
        {
            payment.Status = PaymentStatus.Failed;

            await context.SaveChangesAsync();

            throw new BadRequestException(
                "Payment failed");
        }

        // ==========================================
        // Payment Successful
        // ==========================================

        payment.Status = PaymentStatus.Paid;
        payment.PaidAt = DateTime.UtcNow;
        payment.ReferenceId = GenerateReferenceId();

        payment.Order.Status = OrderStatus.Paid;

        // ==========================================
        // Clear Cart
        // ==========================================

        Cart? cart = await context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c =>
                c.UserId == payment.Order.UserId);

        if (cart != null && cart.CartItems.Any())
        {
            context.CartItems.RemoveRange(cart.CartItems);
        }

        await context.SaveChangesAsync();
    }

    private static PaymentViewModel MapToViewModel(Payment payment)
    {
        return new PaymentViewModel
        {
            PaymentId = payment.Id,
            OrderId = payment.OrderId,
            Amount = payment.Amount,
            Status = payment.Status,
            Authority = payment.Authority,
            ReferenceId = payment.ReferenceId,
            CreatedAt = payment.CreatedAt,
            PaidAt = payment.PaidAt
        };
    }

    private static string GenerateReferenceId()
    {
        return DateTimeOffset.UtcNow
            .ToUnixTimeMilliseconds()
            .ToString();
    }
}
