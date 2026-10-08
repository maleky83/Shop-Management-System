using MediatR;
using ShopManagementSystem.Domain.Enums;

namespace ShopManagementSystem.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<Guid>
{
    public Guid UserId { get; init; }
    public OrderStatus Status { get; init; } = OrderStatus.Pending;
    public decimal TotalPrice { get; init; }
}
