using MediatR;

namespace ShopManagementSystem.Application.Carts.Commands.DeleteCart;

public class DeleteCartCommand(Guid userId) : IRequest<bool>
{
    public Guid UserId { get; } = userId;
}
