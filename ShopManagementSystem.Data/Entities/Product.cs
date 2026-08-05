using ShopManagementSystem.Data.Entities.Category;

namespace ShopManagementSystem.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }
        public string? PictureName { get; set; }

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Item Item { get; set; }
    }
}
