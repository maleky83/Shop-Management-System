using Program.Core.DTOs;
using Program.Data.Entities.Category;

namespace Program.Core.Services.Interfaces
{
    public interface IGroupService
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<ShowGroupViewModel>> GetGroupForShowAsync();

    }

}
