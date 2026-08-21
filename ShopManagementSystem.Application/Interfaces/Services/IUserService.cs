using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.DTOs.Admin;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<User> GetByIdAsync(int id);
        Task<List<UserViewModel>> GetAllAsync();
        public Task<bool> ExistsByNameAsync(string name);
        public Task<User?> GetByNameAsync(string name);
        public Task<List<RoleViewModel>> GetAllRolesAsync();
        Task CreateAsync(CreateUserViewModel model);
        Task CreateForRegisterAsync(RegisterViewModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(UpdateUserViewModel model);
        public Task<UpdateUserViewModel> GetByIdForUpdateAsync(int id);
        //Task<EditUserViewModel> GetUserForUpdateAsync(int id);
        //Task<UserDetailViewModel?> UserDetailAsync(int id);
    }
}
