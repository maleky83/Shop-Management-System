namespace ShopManagementSystem.Application.DTOs.ProductViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductViewModel Product { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}
