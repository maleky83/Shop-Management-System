using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using ShopManagementSystem.Application.Interfaces;
using ShopManagementSystem.Application.DTOs.ProductViewModels;

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
        public ProductViewModel Product { get; set; }

        public async Task OnGetAsync()
        {
            Product = new ProductViewModel()
            {
                Categories = await _productService.GetCategories()
            };
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Product.Categories = await _productService.GetCategories();
                return Page();
            }

            await _productService.AddProductAsync(Product);

            return RedirectToPage("Index");
        }
    }
}