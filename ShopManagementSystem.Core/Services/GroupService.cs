using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Core.DTOs.ProductViewModels;
using ShopManagementSystem.Core.Services.Interfaces;
using ShopManagementSystem.Data.Context;
using ShopManagementSystem.Data.Entities.Category;

namespace ShopManagementSystem.Core.Services
{
    public class GroupService : IGroupService
    {
        private readonly ProgramContext _context;   
        public GroupService(ProgramContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }
        public async Task<List<ShowGroupViewModel>> GetGroupForShowAsync()
        {
            return await _context.Categories.Select(c => new ShowGroupViewModel()
            {
                GroupId = c.Id,
                Name = c.Name,
                ProductCount = c.CategoryToProducts.Count()
            }).AsNoTracking().ToListAsync();
        }
    }
}
