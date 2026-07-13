using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using program.Data;
using program.Models;

namespace program.Pages.Admin.ManageUser
{
    public class IndexModel : PageModel
    {
        private readonly program.Data.ProgramContext _context;

        public IndexModel(program.Data.ProgramContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
