using ShopManagementSystem.Core.DTOs;

namespace ShopManagementSystem.Core.Services.Interfaces
{
    public interface IUserManagerService
    {
        Task CreateAsync(UserViewModel model);
        Task<List<UserViewModel>> GetUsers();
        Task<UserViewModel> DetailAsync(int userId);
        Task DeleteAsync(int id);
        Task EditAsync(EditUserViweModel model);
        Task<EditUserViweModel> GetUserForEditAsync(int userId);
        Task<UserViewModel> GetUserById(int userId);
    }
}
