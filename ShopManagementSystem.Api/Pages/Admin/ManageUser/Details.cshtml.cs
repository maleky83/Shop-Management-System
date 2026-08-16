using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.DTOs.Admin;
using ShopManagementSystem.Application.Interfaces.Services;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class DetailsModel : PageModel
    {
        private readonly IUserService _userAdminService;

        public DetailsModel(IUserService userManager)
        {
            _userAdminService = userManager;
        }

        public UserDetailViewModel? User { get; set; }

        //public async Task<IActionResult> OnGetAsync(int userId)
        //{
        //    User = await _userAdminService.UserDetailAsync(userId);

        //    if (User == null)
        //    {
        //        return NotFound();
        //    }
        //    return Page();
        //}
    }
}
