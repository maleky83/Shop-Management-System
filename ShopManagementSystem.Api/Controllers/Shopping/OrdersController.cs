using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Order;
using ShopManagementSystem.Application.Interfaces.Shopping;

namespace ShopManagementSystem.Api.Controllers.Shopping;

[ApiController]
[Route("orders")]
public sealed class OrdersController(IOrderService orderService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<OrdersCollectionDto>> GetOrders()
    {
        var userId = GetUserId();

        return Ok(await orderService.GetAllAsync(userId));
    }

    [HttpGet("{orderId}")]
    public async Task<ActionResult<OrderDto>> GetOrder(string orderId)
    {
        var userId = GetUserId();

        OrderDto order = await orderService.GetByIdAsync(userId, orderId);

        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrder()
    {
        var userId = GetUserId();

        OrderDto order = await orderService.CreateAsync(userId);

        return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
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
