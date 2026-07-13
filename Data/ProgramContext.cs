using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.EntityFrameworkCore;
using program.Models;

namespace program.Data
{
    public class ProgramContext : DbContext
    {
        public ProgramContext(DbContextOptions<ProgramContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CategoryToProduct>().HasKey(p => new { p.ProductId, p.CategoryId });

            //modelBuilder.Entity<Product>(
            //    p =>
            //    {
            //        p.HasKey(p => p.Id);
            //        p.OwnsOne<Item>(w => w.Item);
            //        p.HasOne<Item>(w => w.Item).WithOne(w => w.Product).HasForeignKey<Item>(w => w.Id);
            //    }
            //    );

            modelBuilder.Entity<Item>(i =>
            {
                i.HasKey(w => w.Id);
                i.Property(i => i.Price).HasColumnType("Money");
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "لباس مردانه",
                Description = "انواع پوشاک رسمی، اسپرت و روزمره برای آقایان با بهترین کیفیت"
            }, new Category
            {
                Id = 2,
                Name = "لباس زنانه",
                Description = "جدیدترین مدل‌های پوشاک زنانه شامل مانتو، شال، کیف و کفش"
            }, new Category
            {
                Id = 3,
                Name = "اکسسوری",
                Description = "ساعت، عینک، کمربند، جواهرات و سایر اکسسوری‌های شیک"
            });

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Price = 1250000M, QuantityInStock = 45 },
                new Item { Id = 2, Price = 980000M, QuantityInStock = 32 },
                new Item { Id = 3, Price = 4500000M, QuantityInStock = 18 }
                );

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                ItemId = 1,
                Name = "پیراهن آستین‌بلند مجلسی طرح‌دار",
                Description = "پیراهن شیک با جنس ترکیبی پنبه و پلی‌استر، مناسب مهمانی‌ها و مجالس رسمی. دارای ۴ سایز و ۳ رنگ مختلف."
            },
            new Product()
            {
                Id = 2,
                ItemId = 2,
                Name = "مانتو نخی بهاره طرح گل‌های کوچک",
                Description = "مانتو سبک و خنک با طرح گل‌های ظریف، جنس نخی درجه یک و رنگ‌بندی شاد. دارای دو جیب کاربردی و قد بلند."
            },
            new Product()
            {
                Id = 3,
                ItemId = 3,
                Name = "ساعت هوشمند اسپرت پرو مدل X-200",
                Description = "ساعت هوشمند با صفحه نمایش AMOLED، حسگرهای پیشرفته سلامت، GPS داخلی و مقاومت در برابر آب تا عمق ۵۰ متر."
            });

            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct() { CategoryId = 1, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 1, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 1, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 3 }
                );


        }

    }
}
