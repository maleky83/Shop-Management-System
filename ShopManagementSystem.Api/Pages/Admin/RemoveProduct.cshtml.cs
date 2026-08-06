using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Core.DTOs.ProductViewModels;
using ShopManagementSystem.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace ShopManagementSystem.Api.Pages.Admin
{
    public class RemoveModel : PageModel
    {
        private readonly IProductService _productService;
        public RemoveModel(IProductService productService)
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
            await _productService.DeleteProductAsync(Product.ProductId);
            return RedirectToPage("Index");
        }
    }
}