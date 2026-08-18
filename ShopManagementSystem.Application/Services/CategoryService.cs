using AutoMapper;
using ShopManagementSystem.Application.DTOs.Category;
using ShopManagementSystem.Application.Interfaces.Repositories;
using ShopManagementSystem.Application.Interfaces.Services;

namespace ShopManagementSystem.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryViewModel>> GetAllAsync()
        {
            var category = await _categoryRepository.GetAllAsync();

            return _mapper.Map<List<CategoryViewModel>>(category);
        }
    }
}
