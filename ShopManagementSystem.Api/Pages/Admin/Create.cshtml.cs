using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.DTOs.Category;
using ShopManagementSystem.Application.DTOs.ProductViewModels;
using ShopManagementSystem.Application.Interfaces.Services;

namespace ShopManagementSystem.Api.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public CreateModel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [BindProperty]
        public CreateProductViewModel CreateProduct { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await _categoryService.GetAllAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Categories = await _categoryService.GetAllAsync();
                return Page();
            }

            await _productService.CreateAsync(CreateProduct);

            return RedirectToPage("Index");
        }
    }
}