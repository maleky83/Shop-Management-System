namespace ShopManagementSystem.Application.Categories.Dtos;

public record UpdateCategoryDto
{
    public int CategoryId { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}
