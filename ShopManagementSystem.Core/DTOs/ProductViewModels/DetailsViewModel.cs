
namespace ShopManagementSystem.Core.DTOs.ProductViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductViewModel Product { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
