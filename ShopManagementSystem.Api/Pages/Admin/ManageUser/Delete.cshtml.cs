using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.Interfaces;
using System.Threading.Tasks;
using ShopManagementSystem.Domain.Entities;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class DeleteModel : PageModel
    {
        private readonly IUserManagerService _userManager;

        public DeleteModel(IUserManagerService userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            await _userManager.DeleteAsync(id);
            return RedirectToPage("Index");
        }
    }
}
