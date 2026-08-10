using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.Interfaces;
using System.Threading.Tasks;
using ShopManagementSystem.Application.DTOs;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class DetailsModel : PageModel
    {
        private readonly IUserManagerService _userManager;

        public DetailsModel(IUserManagerService userManager)
        {
            _userManager = userManager;
        }

        public UserViewModel User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _userManager.DetailAsync(id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
