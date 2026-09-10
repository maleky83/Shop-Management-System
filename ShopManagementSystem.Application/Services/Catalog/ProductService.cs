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
    ApplicationDbContext context,
    IFileService fileService,
    IMapper mapper,
    ICategoryService categoryService
    ) : IProductService
{

    public async Task<ProductViewModel> GetByIdAsync(int id)
    {
        Product? product = await context.Products
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            throw new NotFoundException("Product not found");

        return mapper.Map<ProductViewModel>(product);
    }
    public async Task<Product> GetProductByIdAsync(int id)
    {
        Product? product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            throw new NotFoundException("Product not found");
        }
        return product;
    }

    public async Task<List<ProductViewModel>> GetAllAsync()
    {
        List<Product> products = await context.Products.ToListAsync();

        return mapper.Map<List<ProductViewModel>>(products);
    }

    public async Task CreateAsync(CreateProductViewModel model)
    {
        CategoryViewModel category = await categoryService.GetByIdAsync(model.CategoryId);

        if (category == null)
            throw new NotFoundException("Category not found");

        Product product = mapper.Map<Product>(model);

        if (model.Picture != null)
        {
            product.PictureName = await fileService.SaveFileAsync(model.Picture);
        }

        product.CreatedAt = DateTime.UtcNow;

        await context.AddAsync(product);
        await context.SaveChangesAsync();

    }

    public async Task UpdateAsync(int id, UpdateProductViewModel model)
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

        await context.SaveChangesAsync();
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

        context.Remove(product);
        await context.SaveChangesAsync();
    }

    public async Task<UpdateProductViewModel> GetForUpdateByIdAsync(int id)
    {
        ProductViewModel product = await GetByIdAsync(id);

        return mapper.Map<UpdateProductViewModel>(product);
    }
}
