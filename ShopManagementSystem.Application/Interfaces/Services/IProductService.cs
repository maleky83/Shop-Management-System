using ShopManagementSystem.Application.DTOs.ProductViewModels;

namespace ShopManagementSystem.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task DeleteByIdAsync(int id);
        Task<List<ProductViewModel>> GetAllAsync();
        Task<ProductViewModel?> GetByIdAsync(int id);
        Task CreateAsync(ProductViewModel model);
        Task UpdateAsync(ProductViewModel model);

    }
}
