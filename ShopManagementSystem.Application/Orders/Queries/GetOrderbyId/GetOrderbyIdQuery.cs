using MediatR;
using ShopManagementSystem.Application.Orders.Dtos;

namespace ShopManagementSystem.Application.Orders.Queries.GetOrderbyId;

public class GetOrderbyIdQuery(Guid userId, Guid orderId) : IRequest<OrderDto?>
{
    public Guid UserId { get; } = userId;
    public Guid OrderId { get; } = orderId;
}
