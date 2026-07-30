using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Program.Data.Context;
using Program.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Program.Web.Pages.Admin.ManageUser
{
    public class IndexModel : PageModel
    {
        private readonly ProgramContext _context;

        public IndexModel(ProgramContext context)
        {
            _context = context;
        }

        public IList<User> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
