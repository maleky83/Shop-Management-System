using ShopManagementSystem.Domain.Entities.User;

namespace ShopManagementSystem.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> ExistsByNameAsync(string name);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByNameAsync(string name);
        Task<User?> GetByIdAsync(int id);
        Task CreateAsync(User user);
        Task DeleteAsync(User user);
        Task UpdateAsync(User user);
    }
}
