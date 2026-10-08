namespace ShopManagementSystem.Application.Categories.Dtos;

public record CreateCategoryDto
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}
