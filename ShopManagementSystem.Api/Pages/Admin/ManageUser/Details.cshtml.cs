using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.DTOs.Admin;
using ShopManagementSystem.Application.Interfaces;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class DetailsModel : PageModel
    {
        private readonly IUserAdminService _userAdminService;

        public DetailsModel(IUserAdminService userManager)
        {
            _userAdminService = userManager;
        }

        public UserDetailViewModel? User { get; set; }

        public async Task<IActionResult> OnGetAsync(int userId)
        {
            User = await _userAdminService.UserDetailAsync(userId);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
