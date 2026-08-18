using AutoMapper;
using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Application.DTOs.ProductViewModels;
using ShopManagementSystem.Application.Interfaces.Repositories;
using ShopManagementSystem.Application.Interfaces.Services;
using ShopManagementSystem.Domain.Entities;

namespace ShopManagementSystem.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IFileService _fileService;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IFileService fileService, IProductRepository productRepository, IMapper mapper)
        {
            _fileService = fileService;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductViewModel?> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                throw new Exception("No products");

            var productViewModel = _mapper.Map<ProductViewModel>(product);

            return productViewModel;
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return _mapper.Map<List<ProductViewModel>>(products);
        }

        public async Task CreateAsync(CreateProductViewModel model)
        {
            var product = _mapper.Map<Product>(model);

            if (model.Picture is not null)
            {
                product.PictureName = await _fileService.SaveFileAsync(product.Id, model.Picture);
            }

            // Todo: add CategoryToProduct

            await _productRepository.CreateAsync(product);
            await _productRepository.AddToCategoryAsync(product.Id, model.CategoryIds);


        }

        //public async Task<List<Category>> GetCategories()
        //{
        //    return await _context.Categories.AsNoTracking().ToListAsync();
        //}

        public async Task UpdateAsync(UpdateProductViewModel model)
        {
            var product = await _productRepository.GetByIdAsync(model.ProductId);

            if (product == null)
                throw new Exception("No products");

            var productMap = _mapper.Map<Product>(model);

            if (model.Picture?.Length > 0)
            {
                _fileService.DeleleFile(product.Id, product.PictureName);
                product.PictureName = await _fileService.SaveFileAsync(product.Id, model.Picture);
            }

            await _productRepository.UpdateAsync(productMap);
            //_context.CategoryToProducts.Where(c => c.ProductId == product.Id).ToList()
            //    .ForEach(g => _context.CategoryToProducts.Remove(g));

            //if (model.CategoriIds.Any() && model.CategoriIds.Count > 0)
            //{
            //    foreach (int numberGroup in model.CategoriIds)
            //    {
            //        await _context.CategoryToProducts.CreateAsync(new CategoryToProduct()
            //        {
            //            CategoryId = numberGroup,
            //            ProductId = product.Id
            //        });
            //    }
            //}
            //await _context.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                throw new Exception("No products");

            await _productRepository.DeleteAsync(product);
        }
    }
}
