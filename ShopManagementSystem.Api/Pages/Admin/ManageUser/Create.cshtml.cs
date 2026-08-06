using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Core.DTOs;
using ShopManagementSystem.Core.Services.Interfaces;
using ShopManagementSystem.Data.Context;
using ShopManagementSystem.Data.Entities;
using System.Threading.Tasks;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class CreateModel : PageModel
    {
        private readonly IUserManagerService _userManager;

        public CreateModel(IUserManagerService userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public UserViewModel model { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _userManager.CreateAsync(model);

            return RedirectToPage("Index");
        }
    }
}
