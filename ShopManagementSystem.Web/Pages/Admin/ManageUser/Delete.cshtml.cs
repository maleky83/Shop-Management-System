using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Core.Services.Interfaces;
using ShopManagementSystem.Data.Context;
using ShopManagementSystem.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShopManagementSystem.Web.Pages.Admin.ManageUser
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
