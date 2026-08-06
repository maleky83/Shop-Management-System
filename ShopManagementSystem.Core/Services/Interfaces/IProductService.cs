using ShopManagementSystem.Core.DTOs.ProductViewModels;
using ShopManagementSystem.Data.Entities;
using ShopManagementSystem.Data.Entities.Category;

namespace ShopManagementSystem.Core.Services.Interfaces
{
    public interface IProductService
    {
        Task DeleteProductAsync(int productId);
        Task<List<ProductViewModel>> GetProductsAsync();
        Task<ProductViewModel?> GetProductAsync(int productId);
        Task<ProductDetailsViewModel> GetProductDetails(int productId);
        Task<List<ProductViewModel?>> ShowProductByGroupIdAsync(int categoryId);
        Task AddProductAsync(ProductViewModel model);
        Task EditProductAsync(ProductViewModel model);
        Task<ProductViewModel?> GetProductViewModelAsync(int productId);
        Task<List<Category>> GetCategories();

    }
}
