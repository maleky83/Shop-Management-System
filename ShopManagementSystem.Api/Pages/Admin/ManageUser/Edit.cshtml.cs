using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.DTOs.Admin;
using ShopManagementSystem.Application.Interfaces.Services;

namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;
        public EditModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UpdateUserViewModel model { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public async Task OnGetAsync(int id)
        {
            model = await _userService.GetByIdForUpdateAsync(id);
            Roles = await _userService.GetAllRolesAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid is false)
            {
                model = await _userService.GetByIdForUpdateAsync(model.UserId);
                Roles = await _userService.GetAllRolesAsync();
                return Page();
            }

            await _userService.UpdateAsync(model);

            return RedirectToPage("Index");
        }


    }
}
