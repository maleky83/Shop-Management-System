using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.Carts.Commands.DeleteCart;

public class DeleteCartCommandHandler(
    ILogger<DeleteCartCommandHandler> logger,
    ICartRepository cartRepository
    ) : IRequestHandler<DeleteCartCommand, bool>
{
    public async Task<bool> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting cart user {UserId}", request.UserId);

        Cart? cart = await cartRepository.GetByUserIdAsync(request.UserId);

        if (cart is null)
            return false;

        await cartRepository.DeleteAsync(cart);
        return true;
    }
}
