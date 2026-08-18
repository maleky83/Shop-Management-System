using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.Interfaces.Repositories;
using ShopManagementSystem.Domain.Entities;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProgramContext _context;
        public CategoryRepository(ProgramContext context)
        {
            _context = context;
        }


        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
