using ShopManagementSystem.Domain.Entities.Carts;

namespace ShopManagementSystem.Domain.Repositories.Shopping;

public interface ICartItemRepository
{
    Task AddAsync(Guid userId, CartItem entity);
    Task DeleteAsync(Guid userId, Guid cartItemId);
    Task<IEnumerable<CartItem>> GetAllByCartIdAsync(Guid cartId);
    Task UpdateAsync(Guid userId, Guid cartItemId, CartItem dto);
}
