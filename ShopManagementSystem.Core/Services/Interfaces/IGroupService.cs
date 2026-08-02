using ShopManagementSystem.Core.DTOs.ProductViewModels;
using ShopManagementSystem.Data.Entities.Category;

namespace ShopManagementSystem.Core.Services.Interfaces
{
    public interface IGroupService
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<ShowGroupViewModel>> GetGroupForShowAsync();

    }

}
