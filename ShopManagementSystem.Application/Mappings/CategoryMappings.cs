using System.Linq.Expressions;
using ShopManagementSystem.Application.DTOs.Category;
using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Application.Mappings;

internal static class CategoryMappings
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto
        {
            CategoryId = category.Id,
            Description = category.Description,
            IsActive = category.IsActive,
            Name = category.Name,
        };
    }

    public static Category ToEntity(this CategoryDto dto)
    {
        return new Category
        {
            CreatedAt = DateTime.UtcNow,
            Description = dto.Description,
            Id = $"c_{Guid.CreateVersion7()}",
            IsActive = dto.IsActive,
            Name = dto.Name,
        };
    }
}

internal static class CategoryQueries
{
    public static Expression<Func<Category, CategoryDto>> ProjectToDto()
    {
        return category => new CategoryDto
        {
            CategoryId = category.Id,
            Description = category.Description,
            IsActive = category.IsActive,
            Name = category.Name,
        };
    }
}
