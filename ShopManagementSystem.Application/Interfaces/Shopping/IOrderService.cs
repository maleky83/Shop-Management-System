using ShopManagementSystem.Application.DTOs.Order;

namespace ShopManagementSystem.Application.Interfaces.Shopping;

public interface IOrderService
{
    Task<int> CreateAsync(int userId);
    Task<OrderDto> GetByIdAsync(int userId, int orderId);
    Task<List<OrderDto>> GetAllAsync(int userId);
}
