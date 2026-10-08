using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.Orders.Commands.CreateOrder;
using ShopManagementSystem.Application.Orders.Dtos;
using ShopManagementSystem.Application.Orders.Queries.GetAllOrders;
using ShopManagementSystem.Application.Orders.Queries.GetOrderbyId;

namespace ShopManagementSystem.Api.Controllers.Shopping;

[ApiController]
[Route("orders")]
public sealed class OrdersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
    {
        Guid userId = GetUserId();

        IEnumerable<OrderDto> orderDtos = await mediator.Send(new GetAllOrdersQuery(userId));

        return Ok(orderDtos);
    }

    [HttpGet("{orderId}")]
    public async Task<ActionResult<OrderDto>> GetOrder(Guid orderId)
    {
        Guid userId = GetUserId();

        OrderDto? order = await mediator.Send(new GetOrderbyIdQuery(userId, orderId));

        if (order is null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrder(CreateOrderCommand command)
    {
        Guid userId = GetUserId();

        Guid id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetOrder), new { id });
    }

    private Guid GetUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId is null)
        {
            throw new UnauthorizedAccessException("User invalid");
        }

        return Guid.Parse(userId);
    }
}
