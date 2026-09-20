using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Application.Interfaces.Catalog;

public interface IProductService
{
    Task<ProductsCollectionDto> GetAllAsync();
    Task<ProductDto> GetByIdAsync(string id);
    Task<Product> GetProductByIdAsync(string id);
    Task<ProductDto> CreateAsync(CreateProductDto model);
    Task UpdateAsync(string id, UpdateProductDto model);
    Task DeleteByIdAsync(string id);

}
