using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Core.DTOs;
using ShopManagementSystem.Core.Services.Interfaces;
using ShopManagementSystem.Data.Entities;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopManagementSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;

        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Product product = await _productService.GetProductItemByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(await _productService.DetailsAsync(id));
        }

        [Authorize]
        public async Task<IActionResult> AddToCart(int itemId)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _productService.AddToCartAsync(itemId, userId);
            return RedirectToAction("ShowCart");
        }

        public async Task<IActionResult> ShowCart()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(await _productService.ShowCartAsync(userId));
        }
        [Authorize]
        public async Task<IActionResult> ReduceCart(int detailId)
        {
            int result = await _productService.ReduceCartAsync(detailId);
            if (result == 1)
            {
                return RedirectToAction("RemoveCart", new { detailId });
            }

            return RedirectToAction("ShowCart");
        }

        [Authorize]
        public async Task<IActionResult> RemoveCart(int detailId)
        {
            await _productService.RemoveCartAsync(detailId);

            return RedirectToAction("ShowCart");
        }
        [Authorize]
        public async Task<IActionResult> Payment(int orderId)
        {
            await _productService.PaymentAsync(orderId);
            return View("_Alert", new AlertViewModel { Title = "پرداخت موفق", Alert = "ممنون از خرید و اعتمادتون", TextColor = "text-success" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
