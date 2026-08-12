using ShopManagementSystem.Domain.Entities.Products;

namespace ShopManagementSystem.Domain.Entities.Orders
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public long Price { get; set; }
        public int Count { get; set; }

        #region Relation

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;

        #endregion
    }
}
