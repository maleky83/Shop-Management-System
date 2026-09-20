using ShopManagementSystem.Application.DTOs.Cart;

namespace ShopManagementSystem.Application.Interfaces.Shopping;

public interface ICartService
{
    Task<CartDto> GetAsync(string userId);
    Task<CartItemDto> AddItemAsync(string userId, AddCartiItemDto model);
    Task UpdateItemAsync(string userId, string cartItemId, UpdateCartItemDto model);
    Task DeleteItemAsync(string userId, string cartItemId);
    Task DeleteAsync(string userId);
}
