using System.Security.Claims;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Cart;
using ShopManagementSystem.Application.Interfaces.Shopping;

namespace ShopManagementSystem.Api.Controllers.Shopping;

[ApiController]
[Route("carts/items")]
public sealed class CartItemsController(
    ICartItemService cartItemService
    ) : ControllerBase
{
    private Guid GetUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            throw new UnauthorizedAccessException("Invalid user");
        }

        return Guid.Parse(userId);
    }

    [HttpPut]
    public async Task<ActionResult> AddCartItem(
        [FromBody] AddCartiItemDto addCartiItemDto,
        [FromServices] IValidator<AddCartiItemDto> validator)
    {
        var userId = GetUserId();

        await validator.ValidateAndThrowAsync(addCartiItemDto);

        await cartItemService.AddAsync(userId, addCartiItemDto);

        return Ok();
    }

    [HttpPut("{cartItemId}")]
    public async Task<ActionResult> UpdateCartItem(Guid cartItemId, UpdateCartItemDto updateCartItemDto)
    {
        var userId = GetUserId();
        await cartItemService.UpdateAsync(userId, cartItemId, updateCartItemDto);
        return NoContent();
    }

    [HttpDelete("{cartItemId}")]
    public async Task<ActionResult> DeleteCartItem(Guid cartItemId)
    {
        var userId = GetUserId();
        await cartItemService.DeleteAsync(userId, cartItemId);
        return NoContent();
    }
}
