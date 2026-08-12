namespace ShopManagementSystem.Domain.Entities.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public int ProductId { get; set; }
        public bool IsFinaly { get; set; }

        #region Relation

        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        #endregion
    }
}
