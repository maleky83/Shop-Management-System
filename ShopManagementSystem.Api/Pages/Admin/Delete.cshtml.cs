using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.Interfaces.Services;

namespace ShopManagementSystem.Api.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly IProductService _productService;

        public DeleteModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public int ProductId { get; set; }

        public IActionResult OnGet(int id)
        {
            ProductId = id;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _productService.DeleteByIdAsync(ProductId);

            return RedirectToPage("Index");
        }
    }
}