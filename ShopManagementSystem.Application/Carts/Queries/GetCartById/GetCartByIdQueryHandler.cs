using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Application.Carts.Dtos;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.Carts.Queries.GetCartById;

public class GetCartByIdQueryHandler(
    ILogger<GetCartByIdQueryHandler> logger,
    ICartRepository cartRepository,
    IMapper mapper
    ) : IRequestHandler<GetCartByIdQuery, CartDto?>
{
    public async Task<CartDto?> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get cart by user {UserId}", request.UserId);

        Cart? cart = await cartRepository.GetByUserIdAsync(request.UserId);

        if (cart is null)
            return null;

        CartDto cartDto = mapper.Map<CartDto>(cart);
        return cartDto;
    }
}
