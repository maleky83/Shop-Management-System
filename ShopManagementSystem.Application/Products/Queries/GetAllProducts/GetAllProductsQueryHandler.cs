using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Application.Products.Dtos;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Repositories;

namespace ShopManagementSystem.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(
    ILogger<GetAllProductsQueryHandler> logger,
    IProductRepository productRepository,
    IMapper mapper
    ) :
    IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    public async Task<IEnumerable<ProductDto>> Handle(
        GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all products");

        IEnumerable<Product> products = await productRepository.GetAllAsync();

        IEnumerable<ProductDto> productDtos = mapper.Map<IEnumerable<ProductDto>>(products);

        return productDtos;
    }
}
