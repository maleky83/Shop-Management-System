using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Repositories;

namespace ShopManagementSystem.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(
    IMapper mapper,
    ILogger<CreateProductCommandHandler> logger,
    IProductRepository productRepository,
    IValidator<CreateProductCommand> validator
    ) : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        logger.LogInformation("Creating product {Product}", request);

        Product product = mapper.Map<Product>(request);

        Guid id = await productRepository.CreateAsync(product);

        return id;
    }
}
