using Microsoft.AspNetCore.Http;
using ShopManagementSystem.Data.Entities.Category;

namespace ShopManagementSystem.Core.DTOs.ProductViewModels
{
    public class AddEditProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? PictureName { get; set; }
        public long Price { get; set; }
        public int QuantityInStock { get; set; }
        public IFormFile? Picture { get; set; }
        public List<int> CategoriIds { get; set; } = [];
        public List<Category> Categories { get; set; } = [];
    }
}
