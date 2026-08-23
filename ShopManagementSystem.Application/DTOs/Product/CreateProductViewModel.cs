using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Application.DTOs.Product
{
    public class CreateProductViewModel
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        public IFormFile? Picture { get; set; }

        [Required]
        public required decimal Price { get; set; }

        [Required]
        public required int Quantity { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        public int CategoryId { get; set; }
    }
}