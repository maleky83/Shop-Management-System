using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Order;
using ShopManagementSystem.Application.Interfaces;
using ShopManagementSystem.Application.Interfaces.Shopping;
using System.Security.Claims;

namespace ShopManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        public OrdersController(IOrderService orderService, IPaymentService paymentService)
        {
            _orderService = orderService;
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            int userId = GetUserId();
            int orderId = await _orderService.CreateAsync(userId);
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

            var order = await _orderService.GetByIdAsync(userId, orderId);

            return order;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderViewModel>>> GetAll()
        {
            int userId = GetUserId();
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
}
