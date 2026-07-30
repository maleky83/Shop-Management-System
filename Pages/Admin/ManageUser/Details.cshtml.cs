using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Program.Data.Context;
using Program.Data.Entities;
using System.Linq;
using System.Threading.Tasks;


namespace Program.Web.Pages.Admin.ManageUser
{
    public class DetailsModel : PageModel
    {
        private readonly ProgramContext _context;

        public DetailsModel(ProgramContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
