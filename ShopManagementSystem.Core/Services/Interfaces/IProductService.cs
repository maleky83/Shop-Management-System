using ShopManagementSystem.Core.DTOs.OrderViewModels;
using ShopManagementSystem.Core.DTOs.ProductViewModels;
using ShopManagementSystem.Data.Entities;
using ShopManagementSystem.Data.Entities.Category;

namespace ShopManagementSystem.Core.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product?> GetProductItemByIdAsync(int id);
        Task<DetailsViewModel> DetailsAsync(int id);
        Task AddToOrderAsync(int itemId, int userId);
        Task<OrderViewModel?> ShowOrderAsync(int userId);
        Task<int> ReduceOrderAsync(int detailId);
        Task RemoveOrderAsync(int detailId);
        Task PaymentAsync(int orderId);
        Task<List<Product>> ShowProductByGroupIdAsync(int id);
        Task AddProductAsync(AddEditProductViewModel model, List<int> selectedGroup);
        Task<List<Category>> GetCategories();
    }
}
