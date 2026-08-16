namespace ShopManagementSystem.Domain.Entities;

public class Payment : BaseEntity
{
    public int OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public decimal Amount { get; set; }

    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

    public string? TransactionId { get; set; }

    public DateTime? PaidAt { get; set; }
}