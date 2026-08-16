using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.Interfaces.Services;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class DeleteModel : PageModel
    {
        private readonly IUserService _userAdminService;

        public DeleteModel(IUserService userManager)
        {
            _userAdminService = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int userId)
        {
            await _userAdminService.DeleteAsync(userId);
            return RedirectToPage("Index");
        }
    }
}
