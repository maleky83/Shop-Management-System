using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.DTOs.ProductViewModels;

namespace ShopManagementSystem.Application.Interfaces
{
    public interface IGroupService
    {
        Task<List<CategoryViewModel>> GetAllCategoriesAsync();
        Task<List<ShowGroupViewModel>> GetGroupForShowAsync();

    }

}
