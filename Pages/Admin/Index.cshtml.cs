using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using program.Data;
using program.Models;
using System.Collections;
using System.Collections.Generic;

namespace program.Pages.Admin
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