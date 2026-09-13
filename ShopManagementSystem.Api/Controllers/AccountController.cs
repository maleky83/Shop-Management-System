using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.Interfaces.Authentication;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("account")]
public sealed class AccountController(IAccountService _accountService) : ControllerBase
{

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto model)
    {
        await _accountService.RegisterAsync(model);

        return Ok(new
        {
            message = "Registration successful."
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        LoginResponseDto user = await _accountService.LoginAsync(model);

        return Ok(user);

    }
}
