namespace ShopManagementSystem.Application.DTOs.Product;

public sealed class CreateProductDto
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public required decimal Price { get; set; }

    public required int Quantity { get; set; }

    public bool IsActive { get; set; } = true;

    public required string CategoryId { get; set; }
}
