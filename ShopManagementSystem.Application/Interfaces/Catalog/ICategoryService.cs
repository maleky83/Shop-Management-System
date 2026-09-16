using ShopManagementSystem.Application.DTOs.Category;

namespace ShopManagementSystem.Application.Interfaces.Catalog;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();
    Task<CategoryDto> GetByIdAsync(string id);
}
