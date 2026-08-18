using Microsoft.AspNetCore.Http;

namespace ShopManagementSystem.Application.DTOs.ProductViewModels
{
    public class ProductDetailsViewModel
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? PictureName { get; set; }

        public IFormFile? Picture { get; set; }

        public decimal Price { get; set; }

        public int QuantityInStock { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
