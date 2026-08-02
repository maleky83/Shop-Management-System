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
        public ProductService(ProgramContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductItemByIdAsync(int id)
        {
            Product? product = await _context.Products.Include(p => p.Item).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<DetailsViewModel> DetailsAsync(int id)
        {
            List<Category> categories = await _context.Products.Where(p => p.Id == id).SelectMany(c => c.CategoryToProducts).Select(ca => ca.Category).AsNoTracking().ToListAsync();

            var vm = new DetailsViewModel()
            {
                Product = await GetProductItemByIdAsync(id),
                Categories = categories
            };
            return vm;
        }

        public async Task AddToCartAsync(int itemId, int userId)
        {
            var product = await _context.Products.Include(p => p.Item).AsNoTracking().FirstOrDefaultAsync(p => p.ItemId == itemId);
            if (product != null)
            {
                var order = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.UserId == userId && !o.IsFinaly);

                if (order != null)
                {
                    var orderDetail = await _context.OrderDetail.FirstOrDefaultAsync(d =>
                    d.OrderId == order.OrderId &&
                    d.ProductId == product.Id);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        await _context.OrderDetail.AddAsync(new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            Count = 1,
                            ProductId = product.Id,
                            Price = product.Item.Price
                        });
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    order = new Order()
                    {
                        IsFinaly = false,
                        CreateTime = DateTime.Now,
                        UserId = userId
                    };
                    await _context.Orders.AddAsync(order);
                    await _context.SaveChangesAsync();
                    await _context.OrderDetail.AddAsync(new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        ProductId = product.Id,
                        Price = product.Item.Price,
                        Count = 1
                    });
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Order> ShowCartAsync(int userId)
        {
            var order = await _context.Orders.Where(o => o.UserId == userId && !o.IsFinaly).
                Include(o => o.OrderDetails).
                ThenInclude(c => c.Product).FirstOrDefaultAsync();

            return order;
        }

        public async Task<int> ReduceCartAsync(int detailId)
        {
            var orderDetail = await _context.OrderDetail.FindAsync(detailId);

            if (orderDetail.Count > 1)
            {
                orderDetail.Count -= 1;
            }
            await _context.SaveChangesAsync();

            return orderDetail.Count;
        }

        public async Task RemoveCartAsync(int detailId)
        {
            var orderDetail = await _context.OrderDetail.FindAsync(detailId);
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderDetail.OrderId);
            _context.Remove(orderDetail);
            await _context.SaveChangesAsync();
            var orderDetailCount = await _context.OrderDetail.Where(o => o.OrderId == order.OrderId).SumAsync(o => o.Count);
            if (orderDetailCount == 0)
            {
                _context.Orders.Remove(order);
            }
            await _context.SaveChangesAsync();
        }

        public async Task PaymentAsync(int orderId)
        {
            var order = await _context.Orders.Where(o => o.OrderId == orderId).FirstOrDefaultAsync();
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> ShowProductByGroupIdAsync(int id, string name)
        {
            List<Product> products = await _context.CategoryToProducts
                .Where(c => c.CategoryId == id)
                .Include(c => c.Product)
                .Select(c => c.Product)
                .ToListAsync();

            return products;
        }

        public async Task AddProductAsync(AddEditProductViewModel model, List<int> selectedGroup)
        {
            var item = new Item()
            {
                Price = model.Price,
                QuantityInStock = model.QuantityInStock
            };
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();

            var product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Item = item
            };
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            product.ItemId = product.Id;

            if (model.Picture?.Length > 0)
            {
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/images/",
                    product.Id + ".jpg"
                    //Path.GetExtension(Product.Picture.FileName
                    );
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Picture.CopyToAsync(stream);
                }
            }

            if (selectedGroup.Any() && selectedGroup.Count > 0)
            {
                foreach (int numberGroup in selectedGroup)
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

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }
    }
}
