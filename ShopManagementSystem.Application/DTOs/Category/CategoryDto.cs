namespace ShopManagementSystem.Application.DTOs.Category;

public record CategoryDto
{
    public int CategoryId { get; init; }
    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }

    public bool IsActive { get; init; } = true;
}
