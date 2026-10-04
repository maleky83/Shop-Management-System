using Microsoft.AspNetCore.Mvc;

namespace ShopManagementSystem.Application.DTOs.Product;

public sealed record ProductsQueryParameters
{
    [FromQuery(Name = "s")]
    public string? Search { get; set; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
}
