using MediatR;

namespace ShopManagementSystem.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommand(Guid id) : IRequest<bool>
{
    public Guid Id { get; } = id;
}
