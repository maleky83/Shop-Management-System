using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace ShopManagementSystem.Web.Components
{
    public class ProductGroupsComponent : ViewComponent
    {
        private readonly IGroupService _groupService;
        public ProductGroupsComponent(IGroupService groupService)
        {
            _groupService = groupService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _groupService.GetGroupForShowAsync();
            return View(model);
        }
    }
}
