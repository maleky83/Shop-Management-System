using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Core.DTOs;
using ShopManagementSystem.Core.Services.Interfaces;
using ShopManagementSystem.Data.Context;
using ShopManagementSystem.Data.Entities;
using System.Linq;
using System.Threading.Tasks;


namespace ShopManagementSystem.Web.Pages.Admin.ManageUser
{
    public class DetailsModel : PageModel
    {
        private readonly IUserManagerService _userManager;

        public DetailsModel(IUserManagerService userManager)
        {
            _userManager = userManager;
        }

        public ManagerUserViewModel User { get; set; }

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
