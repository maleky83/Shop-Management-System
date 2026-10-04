using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Domain.Repositories;

public interface IProductRepository
{
    Task<Guid> CreateAsync(Product entity);
    Task DeleteAsync(Guid id);
    public Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task UpdateAsync(Guid id, Product entity);
}
