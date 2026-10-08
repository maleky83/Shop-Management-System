using MediatR;
using ShopManagementSystem.Application.Products.Dtos;

namespace ShopManagementSystem.Application.Products.Queries.GetProductById;

public class GetProductByIdQuery(Guid id) : IRequest<ProductDto?>
{
    public Guid Id { get; } = id;
}
