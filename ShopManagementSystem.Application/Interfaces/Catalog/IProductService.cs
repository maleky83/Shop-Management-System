using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Application.Interfaces.Catalog;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync();
    Task<ProductDto> GetByIdAsync(int id);
    Task<Product> GetProductByIdAsync(int id);
    Task<UpdateProductDto> GetForUpdateByIdAsync(int id);
    Task CreateAsync(CreateProductDto model);
    Task UpdateAsync(int id, UpdateProductDto model);
    Task DeleteByIdAsync(int id);

}
