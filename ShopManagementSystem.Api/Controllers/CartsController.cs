using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Cart;
using ShopManagementSystem.Application.Interfaces.Shopping;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("api/carts")]
public class CartsController : ControllerBase
{
    private readonly ICartService _cartService;
    public CartsController(ICartService cartService)
    {
        _cartService = cartService;
    }

    private int GetUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userId, out var id))
        {
            throw new UnauthorizedAccessException("Invalid user");
        }
        return id;
    }

    [HttpGet]
    public async Task<ActionResult<CartViewModel>> Get()
    {
        var userId = GetUserId();
        CartViewModel cart = await _cartService.GetAsync(userId);
        return Ok(cart);
    }

    [HttpPost("items")]
    public async Task<IActionResult> AddItem(AddCartiItemViewModel model)
    {
        var userId = GetUserId();

        await _cartService.AddItemAsync(userId, model);
        return Ok(new
        {
            message = "CartItem is added"
        });
    }

    [HttpPut("items/{id}")]
    public async Task<IActionResult> UpdateItem(int id, UpdateCartItemViewModel model)
    {
        var userId = GetUserId();
        await _cartService.UpdateItemAsync(userId, id, model);
        return Ok(new
        {
            message = "Cart item is updated"
        });
    }

    [HttpDelete("items/{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var userId = GetUserId();
        await _cartService.DeleteItemAsync(userId, id);
        return Ok(new
        {
            message = "Cart item is deleted"
        });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
        var userId = GetUserId();
        await _cartService.DeleteAsync(userId);
        return Ok(new
        {
            message = "Cart == deleted"
        });
    }
}
