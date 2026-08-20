using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Domain.Entities;
using ShopManagementSystem.Domain.Entities.User;
using ShopManagementSystem.Infrastructure.Data.Configurations;
using ShopManagementSystem.Infrastructure.Data.Seed;

namespace ShopManagementSystem.Infrastructure.Data.Context
{
    public class ProgramContext : DbContext
    {
        public ProgramContext(DbContextOptions<ProgramContext> options) : base(options)
        {

        }

        #region Product

        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        #endregion

        #region User

        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Role> Roles { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData.Seed(modelBuilder);

            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
        }
    }
}
