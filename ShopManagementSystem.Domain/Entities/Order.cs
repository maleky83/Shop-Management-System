namespace ShopManagementSystem.Domain.Entities;

public class Order : BaseEntity
{
    public int UserId { get; set; }

    public User.User User { get; set; } = null!;

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public decimal TotalPrice { get; set; }

    #region Relations

    public ICollection<OrderDetail> OrderDetails { get; set; }
        = new List<OrderDetail>();

    public Payment? Payment { get; set; }

    #endregion
}