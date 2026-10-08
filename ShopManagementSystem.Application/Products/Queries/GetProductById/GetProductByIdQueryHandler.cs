using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Products.Dtos;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Repositories;

namespace ShopManagementSystem.Application.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler(
    ILogger<GetProductByIdQueryHandler> logger,
    IProductRepository productRepository,
    IMapper mapper
    ) :
    IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting product {request.Id}");

        Product? product = await productRepository.GetByIdAsync(request.Id);

        if (product == null)
            throw new NotFoundException("Product not found");

        ProductDto productDto = mapper.Map<ProductDto>(product);

        return productDto;
    }
}
