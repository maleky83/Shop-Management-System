using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Order;
using ShopManagementSystem.Application.Interfaces.Shopping;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("api/orders")]
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
    public async Task<ActionResult<OrderViewModel>> GetById(int orderId)
    {
        var userId = GetUserId();

        OrderViewModel order = await _orderService.GetByIdAsync(userId, orderId);

        return order;
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderViewModel>>> GetAll()
    {
        var userId = GetUserId();
        return await _orderService.GetAllAsync(userId);
    }

    private int GetUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userId, out var id))
        {
            throw new UnauthorizedAccessException("User invalid");
        }
        return id;
    }
}
