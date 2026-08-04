using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Core.DTOs;
using ShopManagementSystem.Core.Services.Interfaces;
using ShopManagementSystem.Data.Entities;
using System.Threading.Tasks;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class EditModel : PageModel
    {
        private readonly IUserManagerService _userManager;

        public EditModel(IUserManagerService userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public EditUserViweModel model { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            model = await _userManager.GetUserForEditAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                model = await _userManager.GetUserForEditAsync(model.Id);
                return Page();
            }

            await _userManager.EditAsync(model);

            return RedirectToPage("Index");
        }
    }
}
