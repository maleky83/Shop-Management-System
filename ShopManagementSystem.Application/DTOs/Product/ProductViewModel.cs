namespace ShopManagementSystem.Application.DTOs.Product;

public record ProductViewModel
{
    public int ProductId { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public string? PictureName { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public int CategoryId { get; init; }
}
