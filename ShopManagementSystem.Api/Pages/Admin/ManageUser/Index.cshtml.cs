using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagementSystem.Application.DTOs.Admin;
using ShopManagementSystem.Application.Interfaces.Services;


namespace ShopManagementSystem.Api.Pages.Admin.ManageUser
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userManager)
        {
            _userService = userManager;
        }

        public IList<UserViewModel> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _userService.GetAllAsync();
        }
    }
}
