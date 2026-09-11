using Microsoft.AspNetCore.Http;

namespace ShopManagementSystem.Application.DTOs.Product;

public record UpdateProductViewModel
{
    public string? Name { get; init; }

    public string? Description { get; init; }

    public IFormFile? Picture { get; init; }

    public decimal Price { get; init; }

    public int Quantity { get; init; }

    public bool IsActive { get; init; } = true;

    public int CategoryId { get; init; }
}
