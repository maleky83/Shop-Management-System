using ShopManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagementSystem.Application.Interfaces.Users
{
    public interface IRoleService
    {
        Task<bool> ExistsRoleByIdAsync(int id);
        public Task<List<RoleViewModel>> GetAllRolesAsync();
    }
}
