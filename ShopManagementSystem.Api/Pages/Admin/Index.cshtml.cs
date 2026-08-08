using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Infrastructure.Context;
using System.Collections.Generic;
using ShopManagementSystem.Domain.Entities.Products;

namespace ShopManagementSystem.Api.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private ProgramContext _context;
        public IndexModel(ProgramContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _context.Products.Include(p => p.Item);
        }
    }
}