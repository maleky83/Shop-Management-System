using Microsoft.EntityFrameworkCore;
using program.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace program.Data.Repositories
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<ShowGroupViewModel>> GetGroupForShowAsync();

    }
    public class GroupRepository : IGroupRepository
    {
        private readonly ProgramContext _context;
        public GroupRepository(ProgramContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<ShowGroupViewModel>> GetGroupForShowAsync()
        {
            return await _context.Categories.Select(c => new ShowGroupViewModel()
            {
                GroupId = c.Id,
                Name = c.Name,
                ProductCount = c.CategoryToProducts.Count()
            }).ToListAsync();
        }
    }
}
