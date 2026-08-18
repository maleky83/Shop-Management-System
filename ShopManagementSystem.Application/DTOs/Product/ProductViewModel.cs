using ShopManagementSystem.Application.DTOs.Category;

namespace ShopManagementSystem.Application.DTOs.ProductViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? PictureName { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public ICollection<int> CategoriIds { get; set; } = [];
        public ICollection<CategoryViewModel> Categories { get; set; } = [];
    }
}
