using ShopManagementSystem.Domain.Entities.Carts;

namespace ShopManagementSystem.Domain.Repositories.Shopping;

public interface ICartRepository
{
    Task DeleteAsync(Guid userId);
    Task<Cart> GetAsync(Guid userId);
}
