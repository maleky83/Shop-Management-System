using ShopManagementSystem.Domain.Entities.Category;
using ShopManagementSystem.Domain.Entities.Orders;

namespace ShopManagementSystem.Domain.Entities.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? PictureName { get; set; }

        #region Relation

        public int ItemId { get; set; }
        public ICollection<CategoryToProduct> CategoryToProducts { get; set; } = new List<CategoryToProduct>();
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public Item Item { get; set; } = null!;

        #endregion
    }
}
