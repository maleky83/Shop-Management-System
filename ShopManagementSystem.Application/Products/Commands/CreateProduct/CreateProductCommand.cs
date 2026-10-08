using MediatR;

namespace ShopManagementSystem.Application.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<Guid>
{
    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public decimal Price { get; set; } = default!;

    public int Quantity { get; set; } = default!;

    public bool IsActive { get; set; } = true;

    public Guid CategoryId { get; set; } = default!;
}
