using MediatR;

namespace ShopManagementSystem.Application.CartItems.Commands.DeleteCartItem;

public class DeleteCartItemCommand(Guid userId, Guid cartItemId) : IRequest<bool>
{
    public Guid UserId { get; set; } = userId;
    public Guid CartItemId { get; set; } = cartItemId;
}
