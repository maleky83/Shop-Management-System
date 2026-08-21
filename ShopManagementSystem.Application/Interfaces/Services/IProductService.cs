using ShopManagementSystem.Application.DTOs.Product;

namespace ShopManagementSystem.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllAsync();
        Task<ProductViewModel> GetByIdAsync(int id);
        Task<UpdateProductViewModel> GetForUpdateByIdAsync(int id);
        Task CreateAsync(CreateProductViewModel model);
        Task UpdateAsync(UpdateProductViewModel model);
        Task DeleteByIdAsync(int id);

    }
}
