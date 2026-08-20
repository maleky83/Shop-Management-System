using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.DTOs.Admin;
using ShopManagementSystem.Application.Interfaces.Services;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;

        public CreateModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public CreateUserViewModel model { get; set; }
        public List<RoleViewModel> Roles { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Roles = await _userService.GetAllRolesAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Roles = await _userService.GetAllRolesAsync();
                return Page();
            }

            await _userService.CreateAsync(model);

            return RedirectToPage("Index");
        }
    }
}
