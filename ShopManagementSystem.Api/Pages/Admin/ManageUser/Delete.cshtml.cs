using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.Interfaces.Services;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class DeleteModel : PageModel
    {
        private readonly IUserService _userService;

        public DeleteModel(IUserService userManager)
        {
            _userService = userManager;
        }

        [BindProperty]
        public int UserId { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            UserId = id;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _userService.DeleteAsync(UserId);
            return RedirectToPage("Index");
        }
    }
}
