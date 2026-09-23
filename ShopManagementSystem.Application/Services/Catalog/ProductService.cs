using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Category;
using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Catalog;
using ShopManagementSystem.Application.Interfaces.Common;
using ShopManagementSystem.Application.Mappings;
using ShopManagementSystem.Application.Mappings.Catalog;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Catalog;

internal sealed class ProductService(
    ApplicationDbContext dbContext,
    IFileService fileService,
    ICategoryService categoryService
    ) : IProductService
{

    public async Task<ProductDto> GetByIdAsync(string id)
    {
        Product? product = await dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            throw new NotFoundException("Product not found");

        return product.ToDto();
    }
    public async Task<Product> GetProductByIdAsync(string id)
    {
        Product? product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            throw new NotFoundException("Product not found");
        }
        return product;
    }

    public async Task<ProductsCollectionDto> GetAllAsync()
    {
        List<ProductDto> products = await dbContext
            .Products
            .Select(ProductQueries.ProjectToDto())
            .ToListAsync();

        var productsCollectionDto = new ProductsCollectionDto
        {
            Data = products
        };
        return productsCollectionDto;
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto model)
    {
        CategoryDto category = await categoryService.GetByIdAsync(model.CategoryId);

        Product product = model.ToEntity();

        if (model.Picture != null)
        {
            product.PictureName = await fileService.SaveFileAsync(model.Picture);
        }

        category.ToEntity().Products.Add(product);

        await dbContext.AddAsync(product);
        await dbContext.SaveChangesAsync();
        return product.ToDto();
    }

    public async Task UpdateAsync(string id, UpdateProductDto model)
    {
        Product product = await GetProductByIdAsync(id);

        if (product == null)
            throw new NotFoundException("Product not found");

        product.UpdateFromDto(model);

        if (model.Picture?.Length > 0)
        {
            if (!string.IsNullOrWhiteSpace(product.PictureName))
            {
                fileService.DeleleFile(product.PictureName);
            }
            product.PictureName = await fileService.SaveFileAsync(model.Picture);
        }

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(string id)
    {
        Product product = await GetProductByIdAsync(id);

        if (product == null)
            throw new NotFoundException("Product not found");

        if (!string.IsNullOrWhiteSpace(product.PictureName))
        {
            fileService.DeleleFile(product.PictureName);
        }

        dbContext.Remove(product);
        await dbContext.SaveChangesAsync();
    }
}
