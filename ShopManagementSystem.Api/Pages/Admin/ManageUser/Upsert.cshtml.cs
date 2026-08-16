using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.DTOs.Admin;
using ShopManagementSystem.Application.Interfaces.Services;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class EditModel : PageModel
    {
        private readonly IUserService _userAdminService;

        public EditModel(IUserService userManager)
        {
            _userAdminService = userManager;
        }

        [BindProperty]
        public EditUserViewModel model { get; set; }

        //public async Task<IActionResult> OnGetAsync(int? userId)
        //{
        //    if (userId != null)
        //    {
        //        model = await _userAdminService.GetUserForUpdateAsync(userId);
        //    }
        //    return Page();
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                model = new EditUserViewModel();
                return Page();
            }

            if (model.UserId == null)
            {
                CreateUserViewModel user = new CreateUserViewModel()
                {
                    Password = model.NewPassword,
                    Name = model.Name,
                    IsAdmin = model.IsAdmin,
                };
                await _userAdminService.CreateAsync(user);
            }
            else
            {
                await _userAdminService.UpdateAsync(model);
            }

            return RedirectToPage("Index");
        }
    }
}
