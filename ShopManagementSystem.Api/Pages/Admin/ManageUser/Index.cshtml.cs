using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.DTOs.Admin;
using ShopManagementSystem.Application.Interfaces.Services;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userAdminService;

        public IndexModel(IUserService userManager)
        {
            _userAdminService = userManager;
        }

        public IList<UserListViewModel> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _userAdminService.GetAllAsync();
        }
    }
}
