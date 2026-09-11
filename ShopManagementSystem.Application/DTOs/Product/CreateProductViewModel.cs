using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ShopManagementSystem.Application.DTOs.Product;

public record CreateProductViewModel
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
    public int CategoryId { get; init; }
}
