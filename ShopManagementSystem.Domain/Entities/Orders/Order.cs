using ShopManagementSystem.Domain.Entities.Identity;
using ShopManagementSystem.Domain.Enums;

namespace ShopManagementSystem.Domain.Entities.Orders;

public sealed class Order
{
    public Guid Id { get; set; } = Guid.Empty;
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; } = default!;

    public User User { get; set; } = null!;

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public decimal TotalPrice { get; set; }

    #region Relations
    public ICollection<OrderDetail> OrderDetails { get; } = default!;
    #endregion
}
