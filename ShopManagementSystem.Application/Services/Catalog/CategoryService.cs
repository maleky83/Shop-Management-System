using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Category;
using ShopManagementSystem.Application.Interfaces.Catalog;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Catalog;

public class CategoryService(IMapper mapper, ApplicationDbContext context) : ICategoryService
{
    public async Task<List<CategoryViewModel>> GetAllAsync()
    {
        List<Category> categories = await context.Categories.ToListAsync();

        return mapper.Map<List<CategoryViewModel>>(categories);

    }

    public async Task<CategoryViewModel> GetByIdAsync(int id)
    {
        Category? category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        return mapper.Map<CategoryViewModel>(category);
    }
}
