using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.DTOs.ProductViewModels;
using ShopManagementSystem.Application.Interfaces;
using ShopManagementSystem.Infrastructure.Context;

namespace ShopManagementSystem.Application.Services
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
