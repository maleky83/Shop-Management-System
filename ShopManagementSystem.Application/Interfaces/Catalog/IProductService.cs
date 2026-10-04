using ShopManagementSystem.Application.DTOs.Product;

namespace ShopManagementSystem.Application.Interfaces.Catalog;

public interface IProductService
{
    Task<ProductsCollectionDto> GetAllAsync();
    Task<ProductDto> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(CreateProductDto createProductDto);
    Task UpdateAsync(Guid id, UpdateProductDto dto);
    Task DeleteAsync(Guid id);
}
