using MediatR;

namespace ShopManagementSystem.Application.CartItems.Commands.UpdateCartItem;

public class UpdateCartItemCommand(Guid userId, Guid cartItemId) : IRequest<bool>
{
    public Guid UserId { get; set; } = userId;
    public Guid CartItemId { get; set; } = cartItemId;
    public int Quantity { get; init; }
}
