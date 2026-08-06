using ShopManagementSystem.Data.Entities.Category;

namespace ShopManagementSystem.Core.DTOs
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
    }
}
