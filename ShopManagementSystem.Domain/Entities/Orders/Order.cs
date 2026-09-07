using ShopManagementSystem.Domain.Entities.Identity;
using ShopManagementSystem.Domain.Enums;

namespace ShopManagementSystem.Domain.Entities.Orders;

public sealed class Order : BaseEntity
{
    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public decimal TotalPrice { get; set; }

    #region Relations

    public ICollection<OrderDetail> OrderDetails { get; }
        = new List<OrderDetail>();

    public ICollection<Payment> Payments { get; } = new List<Payment>();

    #endregion
}
