using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ShopManagementSystem.Application.DTOs.Product;

public sealed record CreateProductDto
{
    [Required]
    public required string Name { get; init; }

    [Required]
    public required string Description { get; init; }

    public IFormFile? Picture { get; init; }

    [Required]
    public required decimal Price { get; init; }

    [Required]
    public required int Quantity { get; init; }

    public bool IsActive { get; init; } = true;

    [Required]
    public required string CategoryId { get; init; }
}
