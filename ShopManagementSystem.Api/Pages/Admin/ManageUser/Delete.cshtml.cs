using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.Interfaces;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class DeleteModel : PageModel
    {
        private readonly IUserAdminService _userAdminService;

        public DeleteModel(IUserAdminService userManager)
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
