namespace ShopManagementSystem.Application.DTOs.Product;

public sealed record ProductsCollectionDto
{
    public required IReadOnlyCollection<ProductDto> Data { get; init; }
}

public sealed record ProductDto
{
    public int ProductId { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public string? PictureName { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public int CategoryId { get; init; }
}
