using ShopManagementSystem.Domain.Enums;

namespace ShopManagementSystem.Application.DTOs;

public class PaymentViewModel
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public decimal Amount { get; set; }

    public PaymentStatus Status { get; set; }

    public string? ReferenceId { get; set; }
    public string? Authority { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? PaidAt { get; set; }
}
