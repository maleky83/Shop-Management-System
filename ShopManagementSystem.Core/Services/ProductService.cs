using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Core.DTOs.ProductViewModels;
using ShopManagementSystem.Core.Services.Interfaces;
using ShopManagementSystem.Data.Context;
using ShopManagementSystem.Data.Entities;
using ShopManagementSystem.Data.Entities.Category;

namespace ShopManagementSystem.Core.Services
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

        public async Task<Product?> GetProductItemByIdAsync(int productId)
        {
            Product? product = await _context.Products.Include(p => p.Item).AsNoTracking().FirstOrDefaultAsync(p => p.Id == productId);
            return product;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<DetailsViewModel> DetailsAsync(int productId)
        {
            List<Category> categories = await _context.Products.Where(p => p.Id == productId).SelectMany(c => c.CategoryToProducts).Select(ca => ca.Category).AsNoTracking().ToListAsync();

            var vm = new DetailsViewModel()
            {
                Product = await GetProductItemByIdAsync(productId),
                Categories = categories
            };
            return vm;
        }

        public async Task<List<Product>> ShowProductByGroupIdAsync(int categoryId)
        {
            List<Product> products = await _context.CategoryToProducts
                .Where(c => c.CategoryId == categoryId)
                .Include(c => c.Product)
                .Select(c => c.Product)
                .ToListAsync();

            return products;
        }

        public async Task AddProductAsync(AddEditProductViewModel model)
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

        public async Task EditProductAsync(AddEditProductViewModel model)
        {
            var product = await _context.Products.FindAsync(model.Id);
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

        public async Task<AddEditProductViewModel?> GetEditProductViewModel(int productId)
        {
            var product = await _context.Products.Include(product => product.Item)
                .Where(product => product.Id == productId)
                .Select(s => new AddEditProductViewModel()
                {
                    Id = productId,
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
