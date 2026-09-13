using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Category;
using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Catalog;
using ShopManagementSystem.Application.Interfaces.Common;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Catalog;

public class ProductService(
    ApplicationDbContext dbContext,
    IFileService fileService,
    IMapper mapper,
    ICategoryService categoryService
    ) : IProductService
{

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        Product? product = await dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            throw new NotFoundException("Product not found");

        return mapper.Map<ProductDto>(product);
    }
    public async Task<Product> GetProductByIdAsync(int id)
    {
        Product? product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            throw new NotFoundException("Product not found");
        }
        return product;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        List<Product> products = await dbContext.Products.ToListAsync();

        return mapper.Map<List<ProductDto>>(products);
    }

    public async Task CreateAsync(CreateProductDto model)
    {
        CategoryDto category = await categoryService.GetByIdAsync(model.CategoryId);

        if (category == null)
            throw new NotFoundException("Category not found");

        Product product = mapper.Map<Product>(model);

        if (model.Picture != null)
        {
            product.PictureName = await fileService.SaveFileAsync(model.Picture);
        }

        product.CreatedAt = DateTime.UtcNow;

        await dbContext.AddAsync(product);
        await dbContext.SaveChangesAsync();

    }

    public async Task UpdateAsync(int id, UpdateProductDto model)
    {
        Product product = await GetProductByIdAsync(id);

        if (product == null)
            throw new NotFoundException("Product not found");

        mapper.Map(model, product);

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

    public async Task DeleteByIdAsync(int id)
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

    public async Task<UpdateProductDto> GetForUpdateByIdAsync(int id)
    {
        ProductDto product = await GetByIdAsync(id);

        return mapper.Map<UpdateProductDto>(product);
    }
}
