using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Core.Services.Interfaces;
using ShopManagementSystem.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagementSystem.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("Group/{id}/{name}")]
        public async Task<IActionResult> ShowProductByGroupId(int id, string name)
        {
            ViewData["GroupTitle"] = name;
            List<Product> products = await _productService.ShowProductByGroupIdAsync(id, name);
            return View(products);
        }
    }
}
