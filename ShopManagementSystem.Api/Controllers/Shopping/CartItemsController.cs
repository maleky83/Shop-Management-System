using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Cart;
using ShopManagementSystem.Application.Interfaces.Shopping;

namespace ShopManagementSystem.Api.Controllers.Shopping;

[ApiController]
[Route("carts/items")]
public sealed class CartItemsController(ICartItemService cartItemService) : ControllerBase
{
    private string GetUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            throw new UnauthorizedAccessException("Invalid user");
        }
        return userId;
    }

    [HttpPut]
    public async Task<ActionResult> AddCartItem(AddCartiItemDto model)
    {
        var userId = GetUserId();

        await cartItemService.AddAsync(userId, model);

        return Ok();
    }

    [HttpPut("{cartItemId}")]
    public async Task<ActionResult> UpdateCartItem(string cartItemId, UpdateCartItemDto model)
    {
        var userId = GetUserId();
        await cartItemService.UpdateAsync(userId, cartItemId, model);
        return NoContent();
    }

    [HttpDelete("{cartItemId}")]
    public async Task<ActionResult> DeleteCartItem(string cartItemId)
    {
        var userId = GetUserId();
        await cartItemService.DeleteAsync(userId, cartItemId);
        return NoContent();
    }
}
