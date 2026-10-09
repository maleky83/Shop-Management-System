using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.CartItems.Commands.CreateCartItem;
using ShopManagementSystem.Application.CartItems.Commands.DeleteCartItem;
using ShopManagementSystem.Application.CartItems.Commands.UpdateCartItem;

namespace ShopManagementSystem.Api.Controllers.Shopping;

[ApiController]
[Route("api/cartItems")]
public sealed class CartItemsController(
    IMediator mediator
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateCartItem(
        [FromBody] CreateCartItemCommand command)
    {
        Guid userId = GetUserId();

        command.UserId = userId;

        var isCreated = await mediator.Send(command);

        if (isCreated)
            return Created();

        return NotFound();
    }

    [HttpPatch("{cartItemId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateCartItem(
       [FromRoute] Guid cartItemId,
       [FromBody] UpdateCartItemCommand command)
    {
        Guid userId = GetUserId();

        command.UserId = userId;
        command.CartItemId = cartItemId;

        var isUpdated = await mediator.Send(command);

        if (isUpdated)
            return NoContent();

        return NotFound();
    }

    [HttpDelete("{cartItemId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCartItem(
        [FromRoute] Guid cartItemId,
        [FromBody] DeleteCartItemCommand command)
    {
        Guid userId = GetUserId();

        command.UserId = userId;
        command.CartItemId = cartItemId;

        var isDeleted = await mediator.Send(command);

        if (isDeleted)
            return NoContent();

        return NotFound();
    }
}
