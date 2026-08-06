using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Data.Entities.Category;
using ShopManagementSystem.Data.Context;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ShopManagementSystem.Core.DTOs.ProductViewModels;
using ShopManagementSystem.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace ShopManagementSystem.Api.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;
        public EditModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ProductViewModel Product { get; set; }

        public async Task OnGetAsync(int productId)
        {
            Product = await _productService.GetProductViewModelAsync(productId);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productService.EditProductAsync(Product);

            return RedirectToPage("Index");
        }
    }
}