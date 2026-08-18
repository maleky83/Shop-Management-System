using ShopManagementSystem.Domain.Entities;

namespace ShopManagementSystem.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
    }
}
