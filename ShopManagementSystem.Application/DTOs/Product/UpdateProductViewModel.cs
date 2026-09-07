using Microsoft.AspNetCore.Http;

namespace ShopManagementSystem.Application.DTOs.Product;

public class UpdateProductViewModel
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public IFormFile? Picture { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public bool IsActive { get; set; } = true;

    public int CategoryId { get; set; }
}
