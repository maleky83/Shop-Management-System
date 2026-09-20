using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Cart;
using ShopManagementSystem.Application.Interfaces.Shopping;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("carts")]
public sealed class CartsController(ICartService cartService) : ControllerBase
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

    [HttpGet]
    public async Task<ActionResult<CartDto>> GetCart()
    {
        var userId = GetUserId();
        CartDto cart = await cartService.GetAsync(userId);
        return Ok(cart);
    }

    [HttpPost("items")]
    public async Task<ActionResult> AddCartItem(AddCartiItemDto model)
    {
        var userId = GetUserId();

        CartItemDto cartItem = await cartService.AddItemAsync(userId, model);

        return CreatedAtAction(nameof(GetCart), cartItem);
    }

    [HttpPut("items/{id}")]
    public async Task<ActionResult> UpdateCartItem(string id, UpdateCartItemDto model)
    {
        var userId = GetUserId();
        await cartService.UpdateItemAsync(userId, id, model);
        return NoContent();
    }

    [HttpDelete("items/{id}")]
    public async Task<ActionResult> DeleteCartItem(string id)
    {
        var userId = GetUserId();
        await cartService.DeleteItemAsync(userId, id);
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteCart()
    {
        var userId = GetUserId();
        await cartService.DeleteAsync(userId);
        return NoContent();
    }
}
