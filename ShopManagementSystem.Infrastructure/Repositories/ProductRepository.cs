using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Repositories;
using ShopManagementSystem.Infrastructure.Persistence;

namespace ShopManagementSystem.Infrastructure.Repositories;

internal class ProductRepository(ApplicationDbContext dbContext) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        List<Product> products = await dbContext.Products.ToListAsync();

        return products;
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        Product? product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

        return product;
    }

    public async Task DeleteAsync(Product entity)
    {
        dbContext.Products.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task<Guid> CreateAsync(Product entity)
    {
        Category? category = await dbContext
            .Categories
            .FirstOrDefaultAsync(c => c.Id == entity.CategoryId);

        if (category is null)
        {
            throw new NotFoundException("not found");
        }

        await dbContext.AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return entity.Id;
    }
}
