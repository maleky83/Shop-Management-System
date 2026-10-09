using ShopManagementSystem.Domain.Entities.Carts;

namespace ShopManagementSystem.Domain.Repositories.Shopping;

public interface ICartItemRepository
{
    Task AddAsync(Guid userId, CartItem entity);
    Task DeleteAsync(CartItem entity);
    Task<IEnumerable<CartItem>> GetAllByCartIdAsync(Guid cartId);
    Task<CartItem?> GetByIdAsync(Guid cartItemId);
    Task SaveChangesAsync();
}
