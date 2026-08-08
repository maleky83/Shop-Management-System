using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Domain.Entities.Category;
using ShopManagementSystem.Infrastructure.Context;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ShopManagementSystem.Application.Interfaces;
using ShopManagementSystem.Application.DTOs.ProductViewModels;

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