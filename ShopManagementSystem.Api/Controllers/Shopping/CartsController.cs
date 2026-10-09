using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.Carts.Commands.DeleteCart;
using ShopManagementSystem.Application.Carts.Dtos;
using ShopManagementSystem.Application.Carts.Queries.GetCartById;

namespace ShopManagementSystem.Api.Controllers.Shopping;

[ApiController]
[Route("carts")]
public class CartsController(IMediator mediator) : ControllerBase
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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CartDto>> GetCart()
    {
        Guid userId = GetUserId();

        CartDto? cart = await mediator.Send(new GetCartByIdQuery(userId));

        if (cart is null)
            return NotFound();

        return Ok(cart);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCart()
    {
        Guid userId = GetUserId();

        var isDeleted = await mediator.Send(new DeleteCartCommand(userId));

        if (isDeleted)
            return NoContent();

        return NotFound();
    }
}
