using ShopManagementSystem.Domain.Entities;

namespace ShopManagementSystem.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task DeleteAsync(Product product);
        Task UpdateAsync(Product product);
        Task CreateAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
    }
}
