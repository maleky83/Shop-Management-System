using ShopManagementSystem.Application.DTOs.Category;

namespace ShopManagementSystem.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllAsync();
        Task<CategoryViewModel> GetByIdAsync(int id);
    }
}
