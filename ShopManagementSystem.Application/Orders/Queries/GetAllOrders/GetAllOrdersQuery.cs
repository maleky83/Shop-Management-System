using MediatR;
using ShopManagementSystem.Application.Orders.Dtos;

namespace ShopManagementSystem.Application.Orders.Queries.GetAllOrders;

public class GetAllOrdersQuery(Guid userId) : IRequest<IEnumerable<OrderDto>>
{
    public Guid UserId { get; } = userId;
}
