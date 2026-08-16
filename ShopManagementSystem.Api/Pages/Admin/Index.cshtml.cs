using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.DTOs.ProductViewModels;
using ShopManagementSystem.Application.Interfaces.Services;

namespace ShopManagementSystem.Api.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public IEnumerable<ProductViewModel> Products { get; set; }
        public async Task OnGetAsync()
        {
            Products = await _productService.GetAllAsync();
        }
    }
}