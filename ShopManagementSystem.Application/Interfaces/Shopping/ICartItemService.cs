using ShopManagementSystem.Application.DTOs.Cart;

namespace ShopManagementSystem.Application.Interfaces.Shopping;

public interface ICartItemService
{
    Task DeleteAsync(Guid userId, Guid cartItemId);
    Task UpdateAsync(Guid userId, Guid cartItemId, UpdateCartItemDto updateCartItemDto);
    Task AddAsync(Guid userId, AddCartiItemDto addCartItemDto);
}
