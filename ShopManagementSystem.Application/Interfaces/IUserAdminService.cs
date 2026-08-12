using ShopManagementSystem.Application.DTOs.Admin;

namespace ShopManagementSystem.Application.Interfaces
{
    public interface IUserAdminService
    {
        Task CreateAsync(CreateUserViewModel model);
        Task<List<UserListViewModel>> GetUsersAsync();
        Task DeleteAsync(int userId);
        Task EditAsync(EditUserViewModel model);
        Task<EditUserViewModel> GetUserForEditAsync(int? userId);
        Task<UserDetailViewModel?> UserDetailAsync(int? userId);
    }
}
