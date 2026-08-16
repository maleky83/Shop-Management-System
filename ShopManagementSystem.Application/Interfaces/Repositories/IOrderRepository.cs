using ShopManagementSystem.Domain.Entities;

namespace ShopManagementSystem.Application.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order);
        Task<Order?> GetByUserIdAsync(int userId);
    }
}
