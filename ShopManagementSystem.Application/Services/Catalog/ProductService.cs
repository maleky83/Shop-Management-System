using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Catalog;
using ShopManagementSystem.Application.Interfaces.Common;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Catalog
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public ProductService(
            IFileService fileService,
            IMapper mapper,
            ApplicationDbContext context,
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

            if (product is null)
                throw new NotFoundException("Product not found");

            return _mapper.Map<ProductViewModel>(product);
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
            {
                throw new NotFoundException("Product not found");
            }
            return product;
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
                throw new NotFoundException("Category not found");

            var product = _mapper.Map<Product>(model);

            if (model.Picture is not null)
            {
                product.PictureName = await _fileService.SaveFileAsync(model.Picture);
            }

            product.CreatedAt = DateTime.UtcNow;

            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(int id, UpdateProductViewModel model)
        {
            var product = await GetProductByIdAsync(id);

            if (product is null)
                throw new NotFoundException("Product not found");

            _mapper.Map(model, product);

            if (model.Picture?.Length > 0)
            {
                _fileService.DeleleFile(product.PictureName);
                product.PictureName = await _fileService.SaveFileAsync(model.Picture);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var product = await GetProductByIdAsync(id);

            if (product is null)
                throw new NotFoundException("Product not found");

            _fileService.DeleleFile(product.PictureName);

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
