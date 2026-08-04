using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopManagementSystem.Core.DTOs.ProductViewModels;

namespace ShopManagementSystem.Api.Pages.Admin
{
    public class AddModel : PageModel
    {
        private readonly IProductService _productService;
        public AddModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public AddEditProductViewModel Product { get; set; }

        [BindProperty]
        public List<int> selectedGroup { get; set; }
        public async Task OnGetAsync()
        {
            Product = new AddEditProductViewModel()
            {
                Categories = await _productService.GetCategories()
            };
        }
        public async Task<IActionResult> OnPostAsync()
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