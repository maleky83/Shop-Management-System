using ShopManagementSystem.Application.DTOs.Order;

namespace ShopManagementSystem.Application.Interfaces.Shopping;

public interface IOrderService
{
    Task<Guid> CreateAsync(Guid userId);
    Task<OrdersCollectionDto> GetAllAsync(Guid userId);
    Task<OrderDto> GetByIdAsync(Guid userId, Guid orderId);
}
