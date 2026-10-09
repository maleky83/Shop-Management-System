using ShopManagementSystem.Domain.Entities.Carts;

namespace ShopManagementSystem.Domain.Repositories.Shopping;

public interface ICartRepository
{
    Task DeleteAsync(Cart entity);
    Task<Cart?> GetByUserIdAsync(Guid userId);
}
