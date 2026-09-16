using ShopManagementSystem.Application.DTOs;

namespace ShopManagementSystem.Application.Interfaces;

public interface IPaymentService
{
    Task<PaymentDto> CreatePaymentAsync(string userId, string orderId);
    Task VerifyPaymentAsync(string authority);
}
