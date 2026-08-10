using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopManagementSystem.Application.DTOs;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class IndexModel : PageModel
    {
        private readonly IUserManagerService _userManager;

        public IndexModel(IUserManagerService userManager)
        {
            _userManager = userManager;
        }

        public IList<UserViewModel> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _userManager.GetUsers();
        }
    }
}
