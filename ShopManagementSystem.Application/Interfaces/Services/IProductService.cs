using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllAsync();
        Task<ProductViewModel> GetByIdAsync(int id);
        Task<Product> GetProductByIdAsync(int id);
        Task<UpdateProductViewModel> GetForUpdateByIdAsync(int id);
        Task CreateAsync(CreateProductViewModel model);
        Task UpdateAsync(int id, UpdateProductViewModel model);
        Task DeleteByIdAsync(int id);

    }
}
