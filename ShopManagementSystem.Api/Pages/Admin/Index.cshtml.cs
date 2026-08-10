using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ShopManagementSystem.Application.Interfaces;
using ShopManagementSystem.Application.DTOs.ProductViewModels;
using System.Threading.Tasks;

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
            Products = await _productService.GetProductsAsync();
        }
    }
}