using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.DTOs.Admin;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<bool> ExistsByNameAsync(string name);
        public Task<UserViewModel> GetByIdAsync(int id);
        Task<List<UserViewModel>> GetAllAsync();
        public Task<UserViewModel> GetByNameAsync(string name);
        public Task<User> GetUserByIdAsync(int id);
        public Task<UpdateUserViewModel> GetByIdForUpdateAsync(int id);
        public Task<User> GetUserByNameAsync(string name);
        public Task<List<RoleViewModel>> GetAllRolesAsync();
        Task CreateAsync(CreateUserViewModel model);
        Task CreateForRegisterAsync(RegisterViewModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, UpdateUserViewModel model);
    }
}
