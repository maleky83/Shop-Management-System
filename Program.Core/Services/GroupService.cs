using Microsoft.EntityFrameworkCore;
using Program.Core.DTOs;
using Program.Core.Services.Interfaces;
using Program.Data.Context;
using Program.Data.Entities.Category;

namespace Program.Core.Services
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
