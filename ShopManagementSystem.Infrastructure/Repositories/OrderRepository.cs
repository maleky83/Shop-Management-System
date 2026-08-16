using ShopManagementSystem.Application.Interfaces.Repositories;
using ShopManagementSystem.Domain.Entities;

namespace ShopManagementSystem.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task CreateAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
