using ShopManagementSystem.Domain.Entities.Orders;

namespace ShopManagementSystem.Domain.Repositories.Shopping;

public interface IOrderRepository
{
    Task<Guid> CreateAsync(Guid userId);
    Task<List<Order>> GetAllAsync(Guid userId);
    Task<Order> GetByIdAsync(Guid userId, Guid orderId);
}
