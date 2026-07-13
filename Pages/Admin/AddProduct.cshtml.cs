using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using program.Data;
using program.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace program.Pages.Admin
{
    public class AddModel : PageModel
    {
        private ProgramContext _context;
        public AddModel(ProgramContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddEditProductViewModel Product { get; set; }

        [BindProperty]
        public List<int> selectedGroup { get; set; }
        public void OnGet()
        {
            Product = new AddEditProductViewModel()
            {
                Categories = _context.Categories.ToList()
            };
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var item = new Item()
            {
                Price = Product.Price,
                QuantityInStock = Product.QuantityInStock
            };
            _context.Add(item);
            _context.SaveChanges();

            var product = new Product()
            {
                Name = Product.Name,
                Description = Product.Description,
                Item = item
            };
            _context.Add(product);
            _context.SaveChanges();
            product.ItemId = product.Id;

            if (Product.Picture?.Length > 0)
            {
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/images/",
                    product.Id + ".jpg"
                    //Path.GetExtension(Product.Picture.FileName
                    );
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);
                }
            }

            if(selectedGroup.Any()&&selectedGroup.Count > 0)
            {
                foreach(int numberGroup in selectedGroup)
                {
                    _context.CategoryToProducts.Add(new CategoryToProduct()
                    {
                        CategoryId = numberGroup,
                        ProductId=product.Id
                        
                    });
                }
            }
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}