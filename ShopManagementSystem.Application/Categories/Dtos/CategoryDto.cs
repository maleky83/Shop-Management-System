namespace ShopManagementSystem.Application.Categories.Dtos;

public sealed record CategoriesCollectionDto
{
    public required IReadOnlyCollection<CategoryDto> Data { get; init; }
}

public sealed record CategoryDto
{
    public required Guid CategoryId { get; init; }
    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }

    public bool IsActive { get; init; } = true;
}
