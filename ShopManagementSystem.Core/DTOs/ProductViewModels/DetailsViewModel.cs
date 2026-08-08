using ShopManagementSystem.Application.DTOs;

namespace ShopManagementSystem.Application.DTOs.ProductViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductViewModel Product { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
