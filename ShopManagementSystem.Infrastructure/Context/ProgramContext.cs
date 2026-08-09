using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Domain.Entities;
using ShopManagementSystem.Domain.Entities.Category;
using ShopManagementSystem.Domain.Entities.Orders;
using ShopManagementSystem.Domain.Entities.Products;

namespace ShopManagementSystem.Infrastructure.Context
{
    public class ProgramContext : DbContext
    {
        public ProgramContext(DbContextOptions<ProgramContext> options) : base(options)
        {

        }

        #region Order

        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Order> Orders { get; set; }

        #endregion

        #region Product

        public DbSet<Item> Items { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }

        #endregion

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryToProduct>().HasKey(p => new { p.ProductId, p.CategoryId });

            modelBuilder.Entity<Item>(i =>
            {
                i.HasKey(w => w.Id);
                i.Property(i => i.Price).HasColumnType("Money");
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Mobile",
                Description = "for call and plaing"
            }, new Category
            {
                Id = 2,
                Name = "laptop",
                Description = "for programming , suding and game"
            }, new Category
            {
                Id = 3,
                Name = "Accessory",
                Description = "for example watch and sock"
            });

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Price = 1250000, QuantityInStock = 45 },
                new Item { Id = 2, Price = 980000, QuantityInStock = 32 },
                new Item { Id = 3, Price = 4500000, QuantityInStock = 18 }
                );

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                ItemId = 1,
                Name = "Sumsung Mobile",
                Description = "ram 6 , memory 128",
                PictureName = "1.jpg",
            },
            new Product()
            {
                Id = 2,
                ItemId = 2,
                Name = "lenovo laptop",
                Description = "ram 16 , memory 1T",
                PictureName = "2.jpg",
            },
            new Product()
            {
                Id = 3,
                ItemId = 3,
                Name = "X-200 sport Watch",
                Description = " AMOLED،GPS ",
                PictureName = "3.jpg",
            });

            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct() { CategoryId = 1, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 3 }
                );
        }
    }
}
