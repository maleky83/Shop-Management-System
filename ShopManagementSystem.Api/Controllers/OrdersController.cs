using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Core.DTOs.OrderViewModels;
using ShopManagementSystem.Core.Services.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("order")]
    public class CartController : ControllerBase
    {
        private IProductService _productService;
        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        [HttpPost("items/{itemId}")]
        public async Task<IActionResult> AddToOrder(int itemId)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _productService.AddToOrderAsync(itemId, userId);

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

            var order = await _productService.ShowOrderAsync(userId);

            if (order == null)
                return BadRequest(new
                {
                    message = "you don't have any oreders"
                });

            return Ok(order);
        }

        [Authorize]
        [HttpPatch("items/{detailId}/decrease")]
        public async Task<IActionResult> ReduceOrder(int detailId)
        {
            int result = await _productService.ReduceOrderAsync(detailId);

            if (result == 1)
                await _productService.RemoveOrderAsync(detailId);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("items/{detailId}")]
        public async Task<IActionResult> RemoveOrder(int detailId)
        {
            await _productService.RemoveOrderAsync(detailId);

            return NoContent();
        }
    }
}
