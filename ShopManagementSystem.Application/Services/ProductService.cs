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
        public ProductService(IFileService fileService, IProductRepository productRepository)
        {
            _fileService = fileService;
            _productRepository = productRepository;
        }

        public async Task<ProductViewModel?> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return null;

            return new ProductViewModel
            {
                Name = product.Name,
                Description = product.Description,
                ProductId = product.Id,
                PictureName = product.PictureName,
                QuantityInStock = product.QuantityInStock,
                Price = product.Price
            };

        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return products.Select(p => new ProductViewModel
            {
                Price = p.Price,
                Description = p.Description,
                Name = p.Name,
                ProductId = p.Id,
                PictureName = p.PictureName,
                QuantityInStock = p.QuantityInStock
            }).ToList();

        }

        //public async Task<ProductDetailsViewModel?> GetDetailsByIdAsync(int productId)
        //{
        //    List<CategoryViewModel> categories = await _context.Products.Where(p => p.Id == productId).SelectMany(c => c.CategoryToProducts).Select(ca => new CategoryViewModel()
        //    {
        //        Description = ca.Category.Description,
        //        Name = ca.Category.Name,
        //        CategoryToProducts = ca.Category.CategoryToProducts,
        //        CategoryId = ca.CategoryId,
        //    }).AsNoTracking().ToListAsync();

        //    var vm = new ProductDetailsViewModel()
        //    {
        //        Product = await GetByIdAsync(productId),
        //        Categories = categories
        //    };
        //    return vm;
        //}

        //public async Task<List<ProductViewModel?>> ShowProductByGroupIdAsync(int categoryId)
        //{
        //    var products = await _context.CategoryToProducts
        //        .Where(c => c.CategoryId == categoryId)
        //        .Select(c => new ProductViewModel()
        //        {
        //            Description = c.Product.Description,
        //            ProductId = c.ProductId,
        //            Name = c.Product.Name,
        //            PictureName = c.Product.PictureName,
        //            Price = c.Product.Price,
        //            QuantityInStock = c.Product.QuantityInStock,

        //        })
        //        .ToListAsync();

        //    return products;
        //}

        public async Task CreateAsync(ProductViewModel model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                QuantityInStock = model.QuantityInStock,
            };

            if (model.Picture is not null)
            {
                product.PictureName = await _fileService.SaveFileAsync(product.Id, model.Picture);
            }

            // Todo: add CategoryToProduct

            await _productRepository.CreateAsync(product);

        }

        //public async Task<List<Category>> GetCategories()
        //{
        //    return await _context.Categories.AsNoTracking().ToListAsync();
        //}

        public async Task UpdateAsync(ProductViewModel model)
        {
            var product = await _productRepository.GetByIdAsync(model.ProductId);
            if (product == null)
                throw new Exception("No product");



            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.QuantityInStock = model.QuantityInStock;
            await _productRepository.UpdateAsync(product);

            //if (model.Picture?.Length > 0)
            //{
            //    _fileService.DeleleFile(product.Id, product.PictureName);
            //    product.PictureName = await _fileService.SaveFileAsync(product.Id, model.Picture);
            //}
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
