using ShopManagementSystem.Core.DTOs;
using ShopManagementSystem.Data.Entities;

namespace ShopManagementSystem.Core.Services.Interfaces
{
    public interface IUserManagerService
    {
        Task CreateAsync(ManagerUserViewModel model);
        Task<List<User>> GetUsers();
        Task<ManagerUserViewModel> DetailAsync(int id);
        Task DeleteAsync(int id);
        Task EditAsync(EditUserViweModel model);
        Task<EditUserViweModel> GetUserForEditAsync(int id);
        Task<ManagerUserViewModel> GetUserById(int id);
    }
}
