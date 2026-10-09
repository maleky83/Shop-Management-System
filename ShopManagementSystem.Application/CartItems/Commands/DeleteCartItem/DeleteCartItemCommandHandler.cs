using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.CartItems.Commands.DeleteCartItem;

public class DeleteCartItemCommandHandler(
    ILogger<DeleteCartItemCommandHandler> logger,
    ICartItemRepository cartItemRepository
    ) : IRequestHandler<DeleteCartItemCommand, bool>
{
    public async Task<bool> Handle(
        DeleteCartItemCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting cartItem {CartItemId}", request.CartItemId);

        CartItem? cartItem = await cartItemRepository.GetByIdAsync(request.CartItemId);

        if (cartItem is null)
            return false;

        await cartItemRepository.DeleteAsync(cartItem);
        return true;
    }
}
