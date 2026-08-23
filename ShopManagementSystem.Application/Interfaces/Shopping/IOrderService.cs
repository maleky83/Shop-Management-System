using ShopManagementSystem.Application.DTOs.Order;
using ShopManagementSystem.Domain.Entities.Orders;

namespace ShopManagementSystem.Application.Interfaces.Shopping
{
    public interface IOrderService
    {
        Task CreateAsync(CreateOrderViewModel model);
        Task DeleteByIdAsync(int id);
        Task<Order> GetByIdAsync(int id);
    }
}
