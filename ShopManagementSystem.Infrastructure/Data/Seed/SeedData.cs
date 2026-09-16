using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Infrastructure.Data.Seed;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        SeedRoles(modelBuilder);
        SeedCategories(modelBuilder);
        SeedProducts(modelBuilder);
        SeedUsers(modelBuilder);

        SeedPermissions(modelBuilder);
        SeedRolePermissions(modelBuilder);
    }

    #region Roles

    private static void SeedRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(new Role
        {
            Id = RoleIds.Admin,
            Name = "Admin"
        }, new Role
        {
            Id = RoleIds.Customer,
            Name = "Customer"
        });
    }

    #endregion

    #region Permissions

    private static void SeedPermissions(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Permission>().HasData(new Permission
        {
            Id = PermissionIds.Read,
            Name = "Read"
        }, new Permission
        {
            Id = PermissionIds.Create,
            Name = "Create"
        }, new Permission
        {
            Id = PermissionIds.Update,
            Name = "Update"
        }, new Permission
        {
            Id = PermissionIds.Delete,
            Name = "Delete"
        });
    }

    #endregion

    #region RolePermissions

    private static void SeedRolePermissions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RolePermission>().HasData(new RolePermission
        {
            RoleId = RoleIds.Admin,
            PermissionId = PermissionIds.Read,
        }, new RolePermission
        {
            RoleId = RoleIds.Admin,
            PermissionId = PermissionIds.Create,
        }, new RolePermission
        {
            RoleId = RoleIds.Admin,
            PermissionId = PermissionIds.Update,
        }, new RolePermission
        {
            RoleId = RoleIds.Admin,
            PermissionId = PermissionIds.Delete,
        }, new RolePermission
        {
            RoleId = RoleIds.Customer,
            PermissionId = PermissionIds.Read,
        });
    }

    #endregion

    #region Products

    private static void SeedProducts(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product()
            {
                Id = $"p_jasdf99-8-asd98asdf",
                Name = "Sumsung Mobile",
                Description = "ram 6 , memory 128",
                PictureName = "1.jpg",
                Price = 20000,
                CategoryId = "c_jasdf99-8-asdf98098asdf",
                Quantity = 10,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            },
            new Product()
            {
                Id = $"p_jasdf99-8-asf",
                Name = "lenovo laptop",
                Description = "ram 16 , memory 1T",
                PictureName = "2.jpg",
                Price = 10000,
                CategoryId = "c_jasdf99-8-asdf98098asdsdf",
                Quantity = 30,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            },
            new Product()
            {
                Id = $"p_sdf23r23-asdf",
                Name = "X-200 sport Watch",
                Description = " AMOLED،GPS ",
                PictureName = "3.jpg",
                Price = 30000,
                CategoryId = "c_jasdf99-8-asdf9df",
                Quantity = 20,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            });
    }

    #endregion

    #region Categories

    private static void SeedCategories(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = $"c_jasdf99-8-asdf98098asdf",
            Name = "Mobile",
            Description = "for call and plaing"
        }, new Category
        {
            Id = $"c_jasdf99-8-asdf98098asdsdf",
            Name = "laptop",
            Description = "for programming , suding and game"
        }, new Category
        {
            Id = $"c_jasdf99-8-asdf9df",
            Name = "Accessory",
            Description = "for example watch and sock"
        });
    }

    #endregion

    #region Users

    private static void SeedUsers(ModelBuilder modelBuilder)
    {
        var user = new User()
        {
            Id = $"u_jasdf99-8-asdf9df",
            IsActive = true,
            Name = "a",
            RoleId = RoleIds.Admin,
        };

        user.PasswordHash = "AQAAAAIAAYagAAAAEGXenaaSLxper4UJoQ+gez+Olv2R2siuXVFVzUk4rVVfRukD/vbVe17dsaU8PNLtgw==";

        modelBuilder.Entity<User>().HasData(user);

    }

    #endregion
}
