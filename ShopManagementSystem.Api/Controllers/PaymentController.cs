using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces;
using System.Security.Claims;

namespace ShopManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("{orderId}/payment")]
        public async Task<ActionResult<PaymentViewModel>> Create(int orderId)
        {
            int userId = GetUserId();
            return await _paymentService.CreatePaymentAsync(userId, orderId);
        }

        private int GetUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userId, out var id))
            {
                throw new UnauthorizedException("User invalid");
            }

            return id;
        }
    }
}
