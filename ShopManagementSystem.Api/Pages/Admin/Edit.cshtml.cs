using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.DTOs.Category;
using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Application.Interfaces.Services;

namespace ShopManagementSystem.Api.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public EditModel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [BindProperty]
        public UpdateProductViewModel Product { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _productService.GetForUpdateByIdAsync(id);
            Categories = await _categoryService.GetAllAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsycn()
        {
            if (ModelState.IsValid is false)
            {
                Product = await _productService.GetForUpdateByIdAsync(Product.ProductId);
                Categories = await _categoryService.GetAllAsync();
                return Page();
            }

            return RedirectToPage("index");
        }
    }
}
