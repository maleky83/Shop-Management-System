using ShopManagementSystem.Application.DTOs.Cart;

namespace ShopManagementSystem.Application.Interfaces.Shopping
{
    public interface ICartService
    {
        Task<CartViewModel> GetAsync(int userId);
        Task AddItemAsync(int userId, AddCartiItemViewModel model);
        Task UpdateItemAsync(int userId, int cartItemId, UpdateCartItemViewModel model);
        Task DeleteItemAsync(int userId, int cartItemId);
        Task DeleteAsync(int userId);
    }
}
