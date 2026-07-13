using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using program.Data;
using program.Models;
using System.Collections.Generic;
using System.Linq;

namespace program.Controllers
{
    public class ProductController : Controller
    {
        private ProgramContext _context;
        public ProductController(ProgramContext context)
        {
            _context = context;
        }
        [Route("Group/{id}/{name}")]
        public IActionResult ShowProductByGroupId(int id, string name)
        {
            ViewData["GroupTitle"] = name;
            List<Product> product = _context.CategoryToProducts
                .Where(c => c.CategoryId == id)
                .Include(c => c.Product)
                .Select(c => c.Product)
                .ToList();
            return View(product);
        }
    }
}
