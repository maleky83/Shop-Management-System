using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Application.DTOs.ProductViewModels;
using ShopManagementSystem.Application.Interfaces.Services;
using ShopManagementSystem.Domain.Entities;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ProgramContext _context;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public ProductService(
            IFileService fileService,
            IMapper mapper,
            ProgramContext context,
            ICategoryService categoryService)
        {
            _fileService = fileService;
            _mapper = mapper;
            _context = context;
            _categoryService = categoryService;
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                throw new Exception("No products");

            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();

            return _mapper.Map<List<ProductViewModel>>(products);
        }

        public async Task CreateAsync(CreateProductViewModel model)
        {
            var category = await _categoryService.GetByIdAsync(model.CategoryId);

            if (category is null)
                throw new Exception("No categories");

            var product = _mapper.Map<Product>(model);

            if (model.Picture is not null)
            {
                product.PictureName = await _fileService.SaveFileAsync(product.Id, model.Picture);
            }

            product.CreatedAt = DateTime.UtcNow;

            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(UpdateProductViewModel model)
        {
            var product = await GetByIdAsync(model.ProductId);

            if (product == null)
                throw new Exception("No products");

            var productMap = _mapper.Map<Product>(model);

            if (model.Picture?.Length > 0)
            {
                _fileService.DeleleFile(product.ProductId, product.PictureName);
                product.PictureName = await _fileService.SaveFileAsync(product.ProductId, model.Picture);
            }

            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var product = await GetByIdAsync(id);

            if (product == null)
                throw new Exception("No products");

            _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<UpdateProductViewModel> GetForUpdateByIdAsync(int id)
        {
            var product = await GetByIdAsync(id);

            return _mapper.Map<UpdateProductViewModel>(product);
        }
    }
}
