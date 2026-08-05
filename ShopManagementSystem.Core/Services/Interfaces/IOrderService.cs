using ShopManagementSystem.Core.DTOs.OrderViewModels;

namespace ShopManagementSystem.Core.Services.Interfaces
{
    public interface IOrderService
    {
        Task AddToOrderAsync(int itemId, int userId);
        Task<OrderViewModel?> ShowOrderAsync(int userId);
        Task<int> ReduceOrderAsync(int detailId);
        Task RemoveOrderAsync(int detailId);
        Task PaymentAsync(int orderId);
    }
}
