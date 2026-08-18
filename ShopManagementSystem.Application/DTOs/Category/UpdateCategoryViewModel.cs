namespace ShopManagementSystem.Application.DTOs.Category
{
    public class UpdateCategoryViewModel
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
