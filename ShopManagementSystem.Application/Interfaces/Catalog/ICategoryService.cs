using ShopManagementSystem.Application.DTOs.Category;

namespace ShopManagementSystem.Application.Interfaces.Catalog;

public interface ICategoryService
{
    Task<CategoriesCollectionDto> GetAllAsync();
    Task<CategoryDto> GetAsync(Guid id);
}
