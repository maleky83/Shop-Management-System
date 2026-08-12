using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.DTOs.AccountViweModels;
using ShopManagementSystem.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ShopManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;
        public AccountController(IAccountService userService, IConfiguration configuration)
        {
            _accountService = userService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (await _accountService.IsExistUserByNameAsync(model.Name))
            {
                return BadRequest(new
                {
                    message = "Uesr is exist"
                });
            }

            await _accountService.RegisterAsync(model);

            return Ok(new
            {
                message = "register succeed"
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            UserDetailViewModel? user = await _accountService.LoginAsync(model);

            if (user == null)
            {
                return NotFound(new
                {
                    message = "the informaion is not correct"
                });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.Name)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Accepted(new
            {
                token = jwt
            });

        }
    }
}
