using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace ShopManagementSystem.Web.Components
{
    public class GroupsComponent : ViewComponent
    {
        private readonly IGroupService _groupService;
        public GroupsComponent(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _groupService.GetGroupForShowAsync());
        }
    }
}
