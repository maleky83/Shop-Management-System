using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Program.Core.Services.Interfaces;
using Program.Data.Context;
using Program.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Program.Web.Controllers
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
