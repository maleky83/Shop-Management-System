using ShopManagementSystem.Application.DTOs.Order;
using ShopManagementSystem.Domain.Entities.Orders;

namespace ShopManagementSystem.Application.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(CreateOrderViewModel model);
        Task DeleteByIdAsync(int id);
        Task<Order> GetByIdAsync(int id);
    }
}
