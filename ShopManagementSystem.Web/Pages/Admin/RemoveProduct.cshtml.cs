using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Data.Context;
using ShopManagementSystem.Data.Entities;
using System.IO;
using System.Linq;

namespace ShopManagementSystem.Web.Pages.Admin
{
    public class RemoveModel : PageModel
    {
        private ProgramContext _context;
        public RemoveModel(ProgramContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int productId)
        {
            Product = _context.Products.FirstOrDefault(p => p.Id == productId);
        }
        public IActionResult OnPostAsync() 
        {
            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.FirstOrDefault(i => i.Id == product.ItemId);
            _context.Remove(product);
            _context.Remove(item);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                $"wwwroot/images/${product.Id}.jpg");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}