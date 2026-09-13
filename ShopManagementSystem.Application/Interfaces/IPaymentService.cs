using ShopManagementSystem.Application.DTOs;

namespace ShopManagementSystem.Application.Interfaces;

public interface IPaymentService
{
    Task<PaymentDto> CreatePaymentAsync(int userId, int orderId);
    Task VerifyPaymentAsync(string authority);
}
