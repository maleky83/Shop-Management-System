using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Repositories;
using ShopManagementSystem.Infrastructure.Persistence;

namespace ShopManagementSystem.Infrastructure.Repositories;

internal class CategoryRepository(ApplicationDbContext dbContext) : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        List<Category> categories = await dbContext.Categories.ToListAsync();

        return categories;
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        Category? category = await dbContext
            .Categories.FirstOrDefaultAsync(c => c.Id == id);

        return category;
    }
}
