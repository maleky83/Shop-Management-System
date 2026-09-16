using Microsoft.AspNetCore.Http;

namespace ShopManagementSystem.Application.DTOs.Product;

public record UpdateProductDto
{
    public required string Name { get; init; }

    public string? Description { get; init; }

    public IFormFile? Picture { get; init; }

    public decimal Price { get; init; }

    public int Quantity { get; init; }

    public bool IsActive { get; init; } = true;

    public required string CategoryId { get; init; }
}
