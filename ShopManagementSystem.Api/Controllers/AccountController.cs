using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.Interfaces.Authentication;
using ShopManagementSystem.Application.Users.Dtos;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("account")]
public sealed class AccountController(IAccountService accountService) : ControllerBase
{

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
    {
        await accountService.RegisterAsync(registerDto);

        return Ok(new
        {
            message = "Registration successful."
        });
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginDto loginDto)
    {
        LoginResponseDto user = await accountService.LoginAsync(loginDto);

        return Ok(user);

    }
}
