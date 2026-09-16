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
    public async Task<ActionResult<CartDto>> Get()
    {
        var userId = GetUserId();
        CartDto cart = await cartService.GetAsync(userId);
        return Ok(cart);
    }

    [HttpPost("items")]
    public async Task<IActionResult> AddItem(AddCartiItemDto model)
    {
        var userId = GetUserId();

        await cartService.AddItemAsync(userId, model);
        return Ok(new
        {
            message = "CartItem is added"
        });
    }

    [HttpPut("items/{id}")]
    public async Task<IActionResult> UpdateItem(string id, UpdateCartItemDto model)
    {
        var userId = GetUserId();
        await cartService.UpdateItemAsync(userId, id, model);
        return Ok(new
        {
            message = "Cart item is updated"
        });
    }

    [HttpDelete("items/{id}")]
    public async Task<IActionResult> DeleteItem(string id)
    {
        var userId = GetUserId();
        await cartService.DeleteItemAsync(userId, id);
        return Ok(new
        {
            message = "Cart item is deleted"
        });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
        var userId = GetUserId();
        await cartService.DeleteAsync(userId);
        return Ok(new
        {
            message = "Cart == deleted"
        });
    }
}
