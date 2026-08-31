using ShopManagementSystem.Application.DTOs;

namespace ShopManagementSystem.Application.Interfaces.Users
{
    public interface IRoleService
    {
        Task<bool> ExistsRoleByIdAsync(int id);
        public Task<List<RoleViewModel>> GetAllRolesAsync();
    }
}
