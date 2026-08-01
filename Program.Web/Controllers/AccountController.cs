using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Program.Core.DTOs;
using Program.Core.Services.Interfaces;
using Program.Data.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Program.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        public AccountController(IUserService userService, IProductService productService)
        {
            _userService = userService;
            _productService = productService;
        }

        #region Register

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            if (await _userService.GetUserAsync(model.Name) != null)
            {
                ModelState.AddModelError(nameof(model.Name), "نام کاربری وارد شده قبلا ثبت نام کرده است");
                return View(model);
            }

            await _userService.RegisterAsync(model);

            return Redirect("/Account/Login");
        }

        public async Task<IActionResult> VerifyName(string name)
        {
            if (await _userService.GetUserAsync(name) != null)
            {
                return Json($"نام {name} تکراری است");
            }
            return Json(true);
        }
        #endregion

        #region Login

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = await _userService.LoginAsync(model);

            if (user == null)
            {
                ModelState.AddModelError(nameof(model.Name), "اطلاعات صحیح نیست");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim("IsAdmin",user.IsAdmin.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe
            };

            await HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }
        #endregion

        #region Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
        #endregion
    }
}
