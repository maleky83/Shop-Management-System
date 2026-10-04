using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Domain.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(Guid id);
    Task<User> GetUserByNameAsync(string name);
    Task RegisterAsync(User entity);
    Task UpdateAsync(Guid id, User entity);
}
