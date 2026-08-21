using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.Interfaces.Services;


namespace ShopManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/account/")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService userService)
        {
            _accountService = userService;
        }

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
}
