using Program.Core.DTOs;
using Program.Data.Entities;
namespace Program.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserAsync(string name);
        Task AddUserAsync(User user);
        Task RegisterAsync(RegisterViewModel model);
        Task<User?> LoginAsync(LoginViewModel model);
    }
}
