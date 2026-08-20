using ShopManagementSystem.Application.DTOs.Order;
using ShopManagementSystem.Domain.Entities;

namespace ShopManagementSystem.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task CreateAsync(CreateOrderViewModel model);
        Task DeleteByIdAsync(int id);
        Task<Order> GetByIdAsync(int id);
    }
}
