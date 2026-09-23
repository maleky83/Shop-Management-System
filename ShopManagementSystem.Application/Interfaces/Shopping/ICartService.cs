using ShopManagementSystem.Application.DTOs.Cart;

namespace ShopManagementSystem.Application.Interfaces.Shopping;

public interface ICartService
{
    Task<CartDto> GetAsync(string userId);
    Task DeleteAsync(string userId);
}
