using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Repositories;

namespace ShopManagementSystem.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler(
    ILogger<DeleteProductCommandHandler> logger,
    IProductRepository productRepository
    ) : IRequestHandler<DeleteProductCommand, bool>
{
    public async Task<bool> Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting product {ProductId}", request.Id);

        Product? product = await productRepository.GetByIdAsync(request.Id);

        if (product is null)
            return false;

        await productRepository.DeleteAsync(product);
        return true;
    }
}
