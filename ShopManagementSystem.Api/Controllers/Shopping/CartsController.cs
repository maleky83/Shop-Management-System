using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Cart;
using ShopManagementSystem.Application.Interfaces.Shopping;

namespace ShopManagementSystem.Api.Controllers.Shopping;

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

    [HttpDelete]
    public async Task<ActionResult> DeleteCart()
    {
        var userId = GetUserId();
        await cartService.DeleteAsync(userId);
        return NoContent();
    }
}
