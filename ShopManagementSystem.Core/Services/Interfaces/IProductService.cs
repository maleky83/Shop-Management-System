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
        Task AddToCartAsync(int itemId, int userId);
        Task<Order> ShowCartAsync(int userId);
        Task<int> ReduceCartAsync(int detailId);
        Task RemoveCartAsync(int detailId);
        Task PaymentAsync(int orderId);
        Task<List<Product>> ShowProductByGroupIdAsync(int id, string name);
        Task AddProductAsync(AddEditProductViewModel model, List<int> selectedGroup);
        Task<List<Category>> GetCategories();
    }
}
