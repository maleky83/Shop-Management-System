using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Program.Data.Context;
using Program.Data.Entities;
using System.Collections.Generic;

namespace Program.Web.Pages.Admin
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