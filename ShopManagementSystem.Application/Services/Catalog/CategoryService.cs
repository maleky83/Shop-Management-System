using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Category;
using ShopManagementSystem.Application.Interfaces.Catalog;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Catalog;

public class CategoryService(IMapper mapper, ApplicationDbContext context) : ICategoryService
{
    public async Task<List<CategoryDto>> GetAllAsync()
    {
        List<Category> categories = await context.Categories.ToListAsync();

        return mapper.Map<List<CategoryDto>>(categories);

    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        Category? category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        return mapper.Map<CategoryDto>(category);
    }
}
