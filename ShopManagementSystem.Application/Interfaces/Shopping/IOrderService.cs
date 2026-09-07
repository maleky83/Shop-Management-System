using ShopManagementSystem.Application.DTOs.Order;

namespace ShopManagementSystem.Application.Interfaces.Shopping;

public interface IOrderService
{
    Task<int> CreateAsync(int userId);
    Task<OrderViewModel> GetByIdAsync(int userId, int orderId);
    Task<List<OrderViewModel>> GetAllAsync(int userId);
}
