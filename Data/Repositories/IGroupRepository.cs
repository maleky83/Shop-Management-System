using Microsoft.EntityFrameworkCore;
using program.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace program.Data.Repositories
{
    public interface IGroupRepository
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<ShowGroupViewModel> GetGroupForShow();

    }
    public class GroupRepository : IGroupRepository
    {
        private ProgramContext _context;
        public GroupRepository(ProgramContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }
        public IEnumerable<ShowGroupViewModel> GetGroupForShow()
        {
            return _context.Categories.Select(c => new ShowGroupViewModel()
            {
                GroupId = c.Id,
                Name = c.Name,
                ProductCount = c.CategoryToProducts.Count()
            }).ToList();
        }
    }
}
