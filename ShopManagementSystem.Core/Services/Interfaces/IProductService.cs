using ShopManagementSystem.Core.DTOs.ProductViewModels;
using ShopManagementSystem.Data.Entities;
using ShopManagementSystem.Data.Entities.Category;

namespace ShopManagementSystem.Core.Services.Interfaces
{
    public interface IProductService
    {
        Task DeleteProductAsync(int productId);
        Task<List<Product>> GetProductsAsync();
        Task<Product?> GetProductItemByIdAsync(int productId);
        Task<DetailsViewModel> DetailsAsync(int productId);
        Task<List<Product>> ShowProductByGroupIdAsync(int categoryId);
        Task AddProductAsync(AddEditProductViewModel model);
        Task EditProductAsync(AddEditProductViewModel model);
        Task<AddEditProductViewModel?> GetEditProductViewModel(int productId);
        Task<List<Category>> GetCategories();

    }
}
