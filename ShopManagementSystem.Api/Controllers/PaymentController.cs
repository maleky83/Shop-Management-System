using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces;
using System.Security.Claims;

namespace ShopManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("{orderId}/payment")]
        public async Task<ActionResult<PaymentViewModel>> Create(int orderId)
        {
            var userId = GetUserId();

            var payment = await _paymentService.CreatePaymentAsync(
                userId,
                orderId);

            return Ok(payment);
        }

        [HttpGet("payment/verify")]
        public async Task<IActionResult> Verify(string authority)
        {
            await _paymentService.VerifyPaymentAsync(authority);

            return Ok(new
            {
                message = "Payment verified successfully"
            });
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