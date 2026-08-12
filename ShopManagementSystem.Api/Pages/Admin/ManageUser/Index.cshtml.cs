using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.DTOs.Admin;
using ShopManagementSystem.Application.Interfaces;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class IndexModel : PageModel
    {
        private readonly IUserAdminService _userAdminService;

        public IndexModel(IUserAdminService userManager)
        {
            _userAdminService = userManager;
        }

        public IList<UserListViewModel> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _userAdminService.GetUsersAsync();
        }
    }
}
