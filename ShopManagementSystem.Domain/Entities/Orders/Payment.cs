using ShopManagementSystem.Domain.Enums;

namespace ShopManagementSystem.Domain.Entities.Orders;

public sealed class Payment : BaseEntity
{
    public int OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public decimal Amount { get; set; }

    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

    public string? Authority { get; set; }
    public string? ReferenceId { get; set; }

    public DateTime? PaidAt { get; set; }
}
