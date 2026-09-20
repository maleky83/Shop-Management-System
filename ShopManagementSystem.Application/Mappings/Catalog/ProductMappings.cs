using System.Linq.Expressions;
using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Application.Mappings.Catalog;

internal static class ProductMappings
{
    public static ProductDto ToDto(this Product product)
    {
        return new ProductDto
        {
            ProductId = product.Id,
            Description = product.Description,
            Name = product.Name,
            CategoryId = product.CategoryId,
            PictureName = product.PictureName,
            Price = product.Price,
            Quantity = product.Quantity
        };
    }

    public static Product ToEntity(this CreateProductDto dto)
    {
        return new Product
        {
            Id = $"p_{Guid.CreateVersion7()}",
            Name = dto.Name,
            CategoryId = dto.CategoryId,
            CreatedAt = DateTime.UtcNow,
            Description = dto.Description,
            Price = dto.Price,
            Quantity = dto.Quantity,
            IsActive = dto.IsActive,
        };
    }

    public static void UpdateFromDto(this Product product, UpdateProductDto dto)
    {
        product.Name = dto.Name;
        product.CategoryId = dto.CategoryId;
        product.Description = dto.Description;
        product.IsActive = dto.IsActive;
        product.Quantity = dto.Quantity;
        product.Price = dto.Price;
    }
}

internal static class ProductQueries
{
    public static Expression<Func<Product, ProductDto>> ProjectToDto()
    {
        return product => new ProductDto
        {
            ProductId = product.Id,
            Description = product.Description,
            Name = product.Name,
            CategoryId = product.CategoryId,
            PictureName = product.PictureName,
            Price = product.Price,
            Quantity = product.Quantity
        };
    }
}
