using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Entities.Identity;
using ShopManagementSystem.Domain.Entities.Orders;
using ShopManagementSystem.Infrastructure.Seed;

namespace ShopManagementSystem.Infrastructure.Persistence;

internal sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    #region Product

    internal DbSet<OrderDetail> OrderDetail { get; set; }
    internal DbSet<Order> Orders { get; set; }
    internal DbSet<Cart> Carts { get; set; }
    internal DbSet<CartItem> CartItems { get; set; }
    internal DbSet<Product> Products { get; set; }
    internal DbSet<Category> Categories { get; set; }

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

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    }
}
