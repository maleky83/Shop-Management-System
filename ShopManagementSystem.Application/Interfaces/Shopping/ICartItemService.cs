using ShopManagementSystem.Application.DTOs.Cart;

namespace ShopManagementSystem.Application.Interfaces.Shopping;

public interface ICartItemService
{
    Task AddAsync(string userId, AddCartiItemDto model);
    Task UpdateAsync(string userId, string cartItemId, UpdateCartItemDto model);
    Task DeleteAsync(string userId, string cartItemId);

}
