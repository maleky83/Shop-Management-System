using ShopManagementSystem.Application.DTOs.OrderViewModels;
using ShopManagementSystem.Domain.Enums;

namespace ShopManagementSystem.Application.Interfaces
{
    public interface IOrderService
    {
        Task AddToOrderAsync(int itemId, int userId);
        Task<OrderViewModel?> ShowOrderAsync(int userId);
        Task<OrderStatus> ReduceOrderAsync(int detailId, int userId);
        Task<OrderStatus> RemoveOrderAsync(int detailId, int userId);
        Task PaymentAsync(int orderId);
    }
}
