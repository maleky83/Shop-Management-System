using ShopManagementSystem.Application.DTOs.Cart;

namespace ShopManagementSystem.Application.Interfaces.Shopping;

public interface ICartService
{
    Task DeleteAsync(Guid userId);
    Task<CartDto> GetAsync(Guid userId);
}
