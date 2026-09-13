using ShopManagementSystem.Application.DTOs.Cart;

namespace ShopManagementSystem.Application.Interfaces.Shopping;

public interface ICartService
{
    Task<CartDto> GetAsync(int userId);
    Task AddItemAsync(int userId, AddCartiItemDto model);
    Task UpdateItemAsync(int userId, int cartItemId, UpdateCartItemDto model);
    Task DeleteItemAsync(int userId, int cartItemId);
    Task DeleteAsync(int userId);
}
