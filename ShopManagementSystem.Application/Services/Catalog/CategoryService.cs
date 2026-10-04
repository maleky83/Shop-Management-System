using AutoMapper;
using ShopManagementSystem.Application.DTOs.Category;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Catalog;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Repositories;

namespace ShopManagementSystem.Application.Services.Catalog;

public sealed class CategoryService(
    ICategoryRepository categoryRepository,
    IMapper mapper
    ) : ICategoryService
{
    public async Task<CategoriesCollectionDto> GetAllAsync()
    {
        IEnumerable<Category> categories = await categoryRepository.GetAllAsync();

        var categoriesDto = mapper.Map<IReadOnlyCollection<CategoryDto>>(categories);

        CategoriesCollectionDto categoriesCollectionDto = new()
        {
            Data = categoriesDto
        };
        return categoriesCollectionDto;

    }

    public async Task<CategoryDto> GetAsync(Guid id)
    {
        Category? category = await categoryRepository.GetByIdAsync(id);

        if (category is null)
        {
            throw new NotFoundException("Category not found");
        }

        CategoryDto categoryDto = mapper.Map<CategoryDto>(category);

        return categoryDto;
    }
}
