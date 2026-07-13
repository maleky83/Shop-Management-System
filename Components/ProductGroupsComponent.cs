using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using program.Data;
using program.Data.Repositories;
using program.Models;
using System.Linq;
using System.Threading.Tasks;

namespace program.Components
{
    public class ProductGroupsComponent : ViewComponent
    {
        private readonly IGroupRepository _groupRepository;
        public ProductGroupsComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/ProductGroupsComponenet.cshtml",
                _groupRepository.GetGroupForShow());
        }
    }
}
