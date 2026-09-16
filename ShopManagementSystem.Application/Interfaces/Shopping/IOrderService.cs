using ShopManagementSystem.Application.DTOs.Order;

namespace ShopManagementSystem.Application.Interfaces.Shopping;

public interface IOrderService
{
    Task<string> CreateAsync(string userId);
    Task<OrderDto> GetByIdAsync(string userId, string orderId);
    Task<OrdersCollectionDto> GetAllAsync(string userId);
}
