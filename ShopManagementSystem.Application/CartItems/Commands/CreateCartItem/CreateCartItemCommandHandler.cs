using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Repositories;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.CartItems.Commands.CreateCartItem;

public class CreateCartItemCommandHandler(
    ILogger<CreateCartItemCommandHandler> logger,
    IValidator<CreateCartItemCommand> validator,
    ICartItemRepository cartItemRepository,
    IProductRepository productRepository,
    IMapper mapper
    ) : IRequestHandler<CreateCartItemCommand, bool>
{
    public async Task<bool> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating cartItem by user {UserId}", request.UserId);

        await validator.ValidateAndThrowAsync(request, cancellationToken);

        Product? product = await productRepository.GetByIdAsync(request.ProductId);

        if (product is null)
            return false;

        CartItem cartItem = mapper.Map<CartItem>(request);

        cartItem.Price = product.Price;

        await cartItemRepository.AddAsync(request.UserId, cartItem);
        return true;
    }
}
