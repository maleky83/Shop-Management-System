using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Category;
using ShopManagementSystem.Application.Interfaces.Services;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ProgramContext _context;
        public CategoryService(ProgramContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryViewModel>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();

            return _mapper.Map<List<CategoryViewModel>>(categories);

        }

        public async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<CategoryViewModel>(category);
        }
    }
}
