namespace ShopManagementSystem.Application.Products.Dtos;

public sealed record ProductDto
{
    public required Guid ProductId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public required Guid CategoryId { get; init; }
}
