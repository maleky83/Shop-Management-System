using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Category;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Catalog;
using ShopManagementSystem.Application.Mappings;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Catalog;

public class CategoryService(ApplicationDbContext context) : ICategoryService
{
    public async Task<List<CategoryDto>> GetAllAsync()
    {
        List<CategoryDto> categories = await context
            .Categories
            .Select(CategoryQueries.ProjectToDto())
            .ToListAsync();

        return categories;

    }

    public async Task<CategoryDto> GetByIdAsync(string id)
    {
        Category? category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        if (category is null)
        {
            throw new NotFoundException("Category not found");
        }

        return category.ToDto();
    }
}
