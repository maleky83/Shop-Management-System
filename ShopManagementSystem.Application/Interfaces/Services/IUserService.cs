using ShopManagementSystem.Application.DTOs.Admin;

namespace ShopManagementSystem.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserViewModel model);
        Task<List<UserListViewModel>> GetAllAsync();
        Task DeleteAsync(int id);
        Task UpdateAsync(EditUserViewModel model);
        //Task<EditUserViewModel> GetUserForUpdateAsync(int id);
        //Task<UserDetailViewModel?> UserDetailAsync(int id);
    }
}
