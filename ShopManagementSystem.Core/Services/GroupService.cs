using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Core.DTOs;
using ShopManagementSystem.Core.DTOs.ProductViewModels;
using ShopManagementSystem.Core.Services.Interfaces;
using ShopManagementSystem.Data.Context;

namespace ShopManagementSystem.Core.Services
{
    public class GroupService : IGroupService
    {
        private readonly ProgramContext _context;
        public GroupService(ProgramContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoriesAsync()
        {
            return await _context.Categories.Select(c => new CategoryViewModel()
            {
                Description = c.Description,
                Name = c.Name,
                CategoryId= c.Id,
                CategoryToProducts = c.CategoryToProducts,
            }).AsNoTracking().ToListAsync();
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
