using ShopManagementSystem.Application.DTOs;

namespace ShopManagementSystem.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentViewModel> CreatePaymentAsync(int userId, int orderId);
        Task VerifyPaymentAsync(string authority);
    }
}
