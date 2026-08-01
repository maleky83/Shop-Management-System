using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Program.Core.DTOs;
using Program.Core.Services.Interfaces;
using Program.Data.Context;
using Program.Data.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Program.Web.Pages.Admin
{
    public class AddModel : PageModel
    {
        private readonly Core.Services.Interfaces.IProductService _productService;
        public AddModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public AddEditProductViewModel Product { get; set; }

        [BindProperty]
        public List<int> selectedGroup { get; set; }
        public async Task OnGet()
        {
            Product = new AddEditProductViewModel()
            {
                Categories = await _productService.GetCategories()
            };
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           await _productService.AddProductAsync(Product, selectedGroup);

            return RedirectToPage("Index");
        }
    }
}