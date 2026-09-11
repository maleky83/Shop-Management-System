using ShopManagementSystem.Domain.Enums;

namespace ShopManagementSystem.Application.DTOs;

public record PaymentViewModel
{
    public int PaymentId { get; init; }

    public int OrderId { get; init; }

    public decimal Amount { get; init; }

    public PaymentStatus Status { get; init; }

    public string? ReferenceId { get; init; }
    public string? Authority { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime? PaidAt { get; init; }
}
