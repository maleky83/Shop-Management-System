using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Domain.Repositories;

public interface IProductRepository
{
    Task<Guid> CreateAsync(Product entity);
    Task DeleteAsync(Product entity);
    public Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task SaveChangesAsync();
}
