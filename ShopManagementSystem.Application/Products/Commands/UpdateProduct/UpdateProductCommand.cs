using MediatR;

namespace ShopManagementSystem.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public bool IsActive { get; set; } = true;

    public string CategoryId { get; set; } = default!;
}
