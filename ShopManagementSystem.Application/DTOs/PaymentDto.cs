using ShopManagementSystem.Domain.Enums;

namespace ShopManagementSystem.Application.DTOs;

public record PaymentDto
{
    public required string PaymentId { get; init; }

    public required string OrderId { get; init; }

    public decimal Amount { get; init; }

    public PaymentStatus Status { get; init; }

    public string? ReferenceId { get; init; }
    public string? Authority { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime? PaidAt { get; init; }
}
