using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.Interfaces;
using ShopManagementSystem.Infrastructure.Context;
using ShopManagementSystem.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
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
