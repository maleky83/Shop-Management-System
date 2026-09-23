using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces;

namespace ShopManagementSystem.Api.Controllers.Shopping;

[ApiController]
[Route("orders")]
public sealed class PaymentController(IPaymentService paymentService) : ControllerBase
{
    [HttpPost("{orderId}/payment")]
    public async Task<ActionResult<PaymentDto>> CreatePayment(string orderId)
    {
        var userId = GetUserId();

        PaymentDto payment = await paymentService.CreatePaymentAsync(
            userId,
            orderId);

        return Ok(payment);
    }

    [HttpGet("payment/verify")]
    public async Task<ActionResult> Verify(string authority)
    {
        await paymentService.VerifyPaymentAsync(authority);

        return Ok(new
        {
            message = "Payment verified successfully"
        });
    }

    private string GetUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId is null)
        {
            throw new UnauthorizedException("User invalid");
        }

        return userId;
    }
}
