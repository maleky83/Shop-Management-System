using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.Interfaces.Services;
using System.Security.Claims;

namespace ShopManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize]
        [HttpPost("items/{itemId}")]
        public async Task<IActionResult> AddToOrder(int itemId)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            //await _orderService.AddToOrderAsync(itemId, userId);

            return Ok(new
            {
                message = "Product added to order."
            });
        }

        //[Authorize]
        //[HttpGet]
        //public async Task<ActionResult<OrderViewModel>> ShowOrder()
        //{
        //int userId = int.Parse(ClaimTypes.NameIdentifier);

        //var order = await _orderService.ShowOrderAsync(userId);

        //if (order == null)
        //    return BadRequest(new
        //    {
        //        message = "You don't have any orders."
        //    });

        //return Ok(order);
        //}

        //[Authorize]
        //[HttpPatch("items/{detailId}/decrease")]
        //public async Task<IActionResult> ReduceOrder(int detailId, int userId)
        //{
        //    OrderStatus result = await _orderService.ReduceOrderAsync(detailId, int.Parse(ClaimTypes.NameIdentifier));

        //    if (result == OrderStatus.RemoveOrder)
        //        await _orderService.RemoveOrderAsync(detailId, int.Parse(ClaimTypes.NameIdentifier));

        //    if (result == OrderStatus.NotFoundOrderDetail)
        //        return NotFound(new
        //        {
        //            message = "No order details."
        //        });

        //    return Ok(new
        //    {
        //        message = "Order details decreased."
        //    });
        //}

        //[Authorize]
        //[HttpDelete("items/{detailId}")]
        //public async Task<IActionResult> RemoveOrder(int detailId)
        //{
        //    OrderStatus result = await _orderService.RemoveOrderAsync(detailId, int.Parse(ClaimTypes.NameIdentifier));

        //    if (result == OrderStatus.NotFoundOrderDetail)
        //        return NotFound(new
        //        {
        //            message = "No order details."
        //        });

        //    return Ok(new
        //    {
        //        messsage = "Order deleted."
        //    });
        //}
    }
}
