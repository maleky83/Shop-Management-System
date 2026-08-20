using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Application.DTOs.ProductViewModels
{
    public class CreateProductViewModel
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        public string? PictureName { get; set; }

        public IFormFile? Picture { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int QuantityInStock { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        public int CategoryId { get; set; }
    }
}