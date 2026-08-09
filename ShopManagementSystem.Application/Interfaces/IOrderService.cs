using ShopManagementSystem.Application.DTOs.OrderViewModels;

namespace ShopManagementSystem.Application.Interfaces
{
    public interface IOrderService
    {
        Task AddToOrderAsync(int itemId, int userId);
        Task<OrderViewModel?> ShowOrderAsync(int userId);
        Task<int> ReduceOrderAsync(int detailId);
        Task<int?> RemoveOrderAsync(int detailId);
        Task PaymentAsync(int orderId);
    }
}
