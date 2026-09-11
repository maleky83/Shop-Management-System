using Microsoft.AspNetCore.Http;

namespace ShopManagementSystem.Application.DTOs.Product;

public record ProductDetailsViewModel
{
    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }

    public string? PictureName { get; init; }

    public IFormFile? Picture { get; init; }

    public decimal Price { get; init; }

    public int Quantity { get; init; }

    public bool IsActive { get; init; } = true;
}
