using MediatR;
using ShopManagementSystem.Application.Carts.Dtos;

namespace ShopManagementSystem.Application.Carts.Queries.GetCartById;

public class GetCartByIdQuery(Guid userId) : IRequest<CartDto?>
{
    public Guid UserId { get; } = userId;
}
