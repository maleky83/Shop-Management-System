using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Repositories;

namespace ShopManagementSystem.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler(
    ILogger<UpdateProductCommandHandler> logger,
    IMapper mapper,
    IProductRepository productRepository,
    IValidator<UpdateProductCommand> validator
    ) : IRequestHandler<UpdateProductCommand, bool>
{
    public async Task<bool> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating product {request.Id}");

        await validator.ValidateAndThrowAsync(request, cancellationToken);

        Product? product = await productRepository.GetByIdAsync(request.Id);

        if (product is null)
            return false;

        mapper.Map(request, product);

        await productRepository.SaveChangesAsync();
        return true;
    }
}
