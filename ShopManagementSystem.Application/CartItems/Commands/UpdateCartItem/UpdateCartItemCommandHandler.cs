using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.CartItems.Commands.UpdateCartItem;

public class UpdateCartItemCommandHandler(
    ILogger<UpdateCartItemCommandHandler> logger,
    ICartItemRepository cartItemRepository,
    IValidator<UpdateCartItemCommand> validator
    ) : IRequestHandler<UpdateCartItemCommand, bool>
{
    public async Task<bool> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating cartItem {CartItemId}", request.CartItemId);

        await validator.ValidateAndThrowAsync(request, cancellationToken);

        CartItem? cartItem = await cartItemRepository
            .GetByIdAsync(request.CartItemId);

        if (cartItem is null)
            return false;

        cartItem.Quantity = request.Quantity;

        await cartItemRepository.SaveChangesAsync();
        return true;
    }
}
