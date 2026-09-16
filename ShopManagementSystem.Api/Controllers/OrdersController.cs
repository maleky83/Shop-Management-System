using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Order;
using ShopManagementSystem.Application.Interfaces.Shopping;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("orders")]
public sealed class OrdersController(IOrderService _orderService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create()
    {
        var userId = GetUserId();
        var orderId = await _orderService.CreateAsync(userId);
        return Ok(new
        {
            id = orderId,
            message = "Order is created"
        });
    }

    [HttpGet("{orderId}")]
    public async Task<ActionResult<OrderDto>> GetById(string orderId)
    {
        var userId = GetUserId();

        OrderDto order = await _orderService.GetByIdAsync(userId, orderId);

        return order;
    }

    [HttpGet]
    public async Task<ActionResult<OrdersCollectionDto>> GetAll()
    {
        var userId = GetUserId();
        return await _orderService.GetAllAsync(userId);
    }

    private string GetUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId is null)
        {
            throw new UnauthorizedAccessException("User invalid");
        }
        return userId;
    }
}
