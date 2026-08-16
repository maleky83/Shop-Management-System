using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.DTOs.ProductViewModels;
using ShopManagementSystem.Application.Interfaces.Services;

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

        //public async Task OnGetAsync(int? productId)
        //{
        //    if (productId == null)
        //    {
        //        Product = new ProductViewModel()
        //        {
        //            Categories = await _productService.GetCategories()
        //        };
        //    }
        //    else
        //    {
        //        Product = await _productService.GetByIdAsync(productId);
        //    }
        //}
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    Product.Categories = await _productService.GetCategories();
            //    return Page();
            //}

            if (Product.ProductId == 0)
            {
                await _productService.CreateAsync(Product);
            }
            else
            {
                await _productService.UpdateAsync(Product);
            }

            return RedirectToPage("Index");
        }
    }
}