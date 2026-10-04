using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Domain.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(Guid id);
}
