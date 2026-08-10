using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.OrderViewModels;
using ShopManagementSystem.Application.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

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

            await _orderService.AddToOrderAsync(itemId, userId);

            return Ok(new
            {
                message = "Product added to order"
            });
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<OrderViewModel>> ShowOrder()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var order = await _orderService.ShowOrderAsync(userId);

            if (order == null)
                return BadRequest(new
                {
                    message = "you don't have any orders"
                });

            return Ok(order);
        }

        [Authorize]
        [HttpPatch("items/{detailId}/decrease")]
        public async Task<IActionResult> ReduceOrder(int detailId)
        {
            int result = await _orderService.ReduceOrderAsync(detailId);

            if (result == 1)
                await _orderService.RemoveOrderAsync(detailId);

            if (result == 0)
                return BadRequest(new
                {
                    message = "there isn't any OrderDetails"
                });

            return Ok(new
            {
                message = "decreased orderDetail"
            });
        }

        [Authorize]
        [HttpDelete("items/{detailId}")]
        public async Task<IActionResult> RemoveOrder(int detailId)
        {
            var result = await _orderService.RemoveOrderAsync(detailId);

            if (result == null)
                return BadRequest(new
                {
                    message = "there isn't any OrderDetails"
                });

            return Ok(new
            {
                messsage = "Removed Order"
            });
        }
    }
}
