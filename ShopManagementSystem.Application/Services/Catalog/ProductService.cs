using AutoMapper;
using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Catalog;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Repositories;

namespace ShopManagementSystem.Application.Services.Catalog;

public sealed class ProductService(
    IProductRepository productRepository,
    IMapper mapper
    ) : IProductService
{

    public async Task<ProductDto> GetByIdAsync(Guid id)
    {
        Product? product = await productRepository.GetByIdAsync(id);

        if (product == null)
            throw new NotFoundException("Product not found");

        ProductDto productDto = mapper.Map<ProductDto>(product);

        return productDto;
    }

    public async Task<ProductsCollectionDto> GetAllAsync()
    {
        IEnumerable<Product> products = await productRepository.GetAllAsync();

        IReadOnlyCollection<ProductDto> productDto = mapper.Map<IReadOnlyCollection<ProductDto>>(products);

        var productsCollectionDto = new ProductsCollectionDto
        {
            Data = productDto
        };
        return productsCollectionDto;
    }

    public async Task<Guid> CreateAsync(CreateProductDto createProductDto)
    {
        Product product = mapper.Map<Product>(createProductDto);

        Guid id = await productRepository.CreateAsync(product);

        return id;
    }

    public async Task UpdateAsync(Guid id, UpdateProductDto dto)
    {
        Product product = mapper.Map<Product>(dto);

        await productRepository.UpdateAsync(id, product);
    }

    public async Task DeleteAsync(Guid id)
    {
        await productRepository.DeleteAsync(id);
    }
}
