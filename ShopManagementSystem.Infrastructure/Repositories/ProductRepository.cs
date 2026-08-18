using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.Interfaces.Repositories;
using ShopManagementSystem.Domain.Entities;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ProgramContext _context;
        public ProductRepository(ProgramContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task AddToCategoryAsync(int id, List<int> categoryIds)
        {
            foreach (var categoryId in categoryIds)
            {
                await _context.CategoryToProducts.AddAsync(new CategoryToProduct
                {
                    CategoryId = categoryId,
                    ProductId = id
                });
            }
            await _context.SaveChangesAsync();
        }
    }
}
