using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.Interfaces.Authentication;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("api/account")]
public sealed class AccountController(IAccountService _accountService) : ControllerBase
{

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        await _accountService.RegisterAsync(model);

        return Ok(new
        {
            message = "Registration successful."
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        LoginResponseViewModel user = await _accountService.LoginAsync(model);

        return Ok(user);

    }
}
