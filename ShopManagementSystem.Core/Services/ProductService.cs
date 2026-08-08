using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.Interfaces;
using ShopManagementSystem.Infrastructure.Context;
using ShopManagementSystem.Domain.Entities.Products;
using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.DTOs.ProductViewModels;
using ShopManagementSystem.Domain.Entities.Category;

namespace ShopManagementSystem.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ProgramContext _context;
        private readonly IFileService _fileService;
        public ProductService(ProgramContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<ProductViewModel?> GetProductAsync(int productId)
        {
            var product = await _context.Products.AsNoTracking().Select(p => new ProductViewModel()
            {
                ProductId = p.Id,
                Description = p.Description,
                Name = p.Name,
                PictureName = p.PictureName,
                Price = p.Item.Price,
                QuantityInStock = p.Item.QuantityInStock,

            }).FirstOrDefaultAsync(p => p.ProductId == productId);
            return product;
        }

        public async Task<List<ProductViewModel>> GetProductsAsync()
        {
            return await _context.Products.AsNoTracking().Select(p => new ProductViewModel()
            {
                ProductId = p.Id,
                Description = p.Description,
                Name = p.Name,
                PictureName = p.PictureName,
                Price = p.Item.Price,
                QuantityInStock = p.Item.QuantityInStock,
            })
                .ToListAsync();
        }

        public async Task<ProductDetailsViewModel> GetProductDetails(int productId)
        {
            List<CategoryViewModel> categories = await _context.Products.Where(p => p.Id == productId).SelectMany(c => c.CategoryToProducts).Select(ca => new CategoryViewModel()
            {
                Description = ca.Category.Description,
                Name = ca.Category.Name,
                CategoryToProducts = ca.Category.CategoryToProducts,
                CategoryId= ca.CategoryId,
            }).AsNoTracking().ToListAsync();

            var vm = new ProductDetailsViewModel()
            {
                Product = await GetProductAsync(productId),
                Categories = categories
            };
            return vm;
        }

        public async Task<List<ProductViewModel?>> ShowProductByGroupIdAsync(int categoryId)
        {
            var products = await _context.CategoryToProducts
                .Where(c => c.CategoryId == categoryId)
                .Select(c => new ProductViewModel()
                {
                    Description = c.Product.Description,
                    ProductId= c.ProductId,
                    Name = c.Product.Name,
                    PictureName = c.Product.PictureName,
                    Price = c.Product.Item.Price,
                    QuantityInStock = c.Product.Item.QuantityInStock,

                })
                .ToListAsync();

            return products;
        }

        public async Task AddProductAsync(ProductViewModel model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Item = new Item
                {
                    Price = model.Price,
                    QuantityInStock = model.QuantityInStock,
                }
            };
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

            if (model.Picture is not null)
            {
                product.PictureName = await _fileService.SaveFileAsync(product.Id, model.Picture);
            }

            if (model.CategoriIds.Any())
            {
                await _context.CategoryToProducts.AddRangeAsync(
                    model.CategoriIds.Select(id => new CategoryToProduct()
                    {
                        ProductId = product.Id,
                        CategoryId = id,
                    })
                    );
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task EditProductAsync(ProductViewModel model)
        {
            var product = await _context.Products.FindAsync(model.ProductId);
            var item = await _context.Items.FirstAsync(item => item.Id == product.ItemId);

            product.Name = model.Name;
            product.Description = model.Description;
            item.Price = model.Price;
            item.QuantityInStock = model.QuantityInStock;
            await _context.SaveChangesAsync();

            if (model.Picture?.Length > 0)
            {
                _fileService.DeleleFile(product.Id, product.PictureName);
                product.PictureName = await _fileService.SaveFileAsync(product.Id, model.Picture);
            }
            _context.CategoryToProducts.Where(c => c.ProductId == product.Id).ToList()
                .ForEach(g => _context.CategoryToProducts.Remove(g));

            if (model.CategoriIds.Any() && model.CategoriIds.Count > 0)
            {
                foreach (int numberGroup in model.CategoriIds)
                {
                    await _context.CategoryToProducts.AddAsync(new CategoryToProduct()
                    {
                        CategoryId = numberGroup,
                        ProductId = product.Id
                    });
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<ProductViewModel?> GetProductViewModelAsync(int productId)
        {
            var product = await _context.Products.Include(product => product.Item)
                .Where(product => product.Id == productId)
                .Select(s => new ProductViewModel()
                {
                    ProductId= productId,
                    Name = s.Name,
                    Description = s.Description,
                    QuantityInStock = s.Item.QuantityInStock,
                    Price = s.Item.Price,
                    PictureName = s.PictureName,
                }).FirstOrDefaultAsync();

            product.Categories = await _context.Categories.ToListAsync();
            product.CategoriIds = await _context.CategoryToProducts.Where(c => c.ProductId == productId)
                .Select(s => s.CategoryId).ToListAsync();

            return product;
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == product.ItemId);
            _fileService.DeleleFile(productId, product.PictureName);
            _context.Remove(product);
            _context.Remove(item);

            await _context.SaveChangesAsync();
        }
    }
}
