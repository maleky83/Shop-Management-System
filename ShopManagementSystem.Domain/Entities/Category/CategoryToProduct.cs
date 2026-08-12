using ShopManagementSystem.Domain.Entities.Products;

namespace ShopManagementSystem.Domain.Entities.Category
{
    public class CategoryToProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        #region Relation
        public Category Category { get; set; } = null!;
        public Product Product { get; set; } = null!;
        #endregion
    }
}
