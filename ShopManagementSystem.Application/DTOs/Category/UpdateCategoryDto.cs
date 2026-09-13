namespace ShopManagementSystem.Application.DTOs.Category;

public record UpdateCategoryDto
{
    public int CategoryId { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}
