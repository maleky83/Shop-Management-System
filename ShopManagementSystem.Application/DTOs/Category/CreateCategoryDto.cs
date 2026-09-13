namespace ShopManagementSystem.Application.DTOs.Category;

public record CreateCategoryDto
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}
