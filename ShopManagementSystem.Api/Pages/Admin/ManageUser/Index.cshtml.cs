using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Core.DTOs;
using ShopManagementSystem.Core.Services.Interfaces;
using ShopManagementSystem.Data.Context;
using ShopManagementSystem.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class IndexModel : PageModel
    {
        private readonly IUserManagerService _userManager;

        public IndexModel(IUserManagerService userManager)
        {
            _userManager = userManager;
        }

        public IList<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _userManager.GetUsers();
        }
    }
}
