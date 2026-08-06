using ShopManagementSystem.Core.DTOs;
using ShopManagementSystem.Core.DTOs.ProductViewModels;

namespace ShopManagementSystem.Core.Services.Interfaces
{
    public interface IGroupService
    {
        Task<List<CategoryViewModel>> GetAllCategoriesAsync();
        Task<List<ShowGroupViewModel>> GetGroupForShowAsync();

    }

}
