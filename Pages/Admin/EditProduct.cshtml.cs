using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using program.Data;
using program.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace program.Pages.Admin
{
    public class EditModel : PageModel
    {
        private ProgramContext _context;
        public EditModel(ProgramContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddEditProductViewModel Product { get; set; }
        [BindProperty]
        public List<int> selectedGroup { get; set; }
        public List<int> GroupsProduct { get; set; }
        public void OnGet(int id)
        {
            var product = _context.Products.Include(product => product.Item)
                .Where(product => product.Id == id)
                .Select(s => new AddEditProductViewModel()
                {
                    Id = id,
                    Name = s.Name,
                    Description = s.Description,
                    QuantityInStock = s.Item.QuantityInStock,
                    Price = s.Item.Price
                }).FirstOrDefault();

            Product = product;
            product.Categories = _context.Categories.ToList();
            GroupsProduct = _context.CategoryToProducts.Where(c => c.ProductId == id)
                .Select(s => s.CategoryId).ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(item => item.Id == product.ItemId);

            product.Name = Product.Name;
            product.Description = Product.Description;
            item.Price = Product.Price;
            item.QuantityInStock = Product.QuantityInStock;
            _context.SaveChanges();

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
            _context.CategoryToProducts.Where(c => c.ProductId == product.Id).ToList()
                .ForEach(g => _context.CategoryToProducts.Remove(g));

            if (selectedGroup.Any() && selectedGroup.Count > 0)
            {
                foreach(int numberGroup in selectedGroup)
                {
                    _context.CategoryToProducts.Add(new CategoryToProduct()
                    {
                        CategoryId = numberGroup,
                        ProductId = product.Id
                    });
                }
            }
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}