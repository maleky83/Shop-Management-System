using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Infrastructure.Seed;

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
            new Product
            {
                Id = Guid.Parse("b4e72c19-6f35-4a81-9d27-58c3e1f60492"),
                Name = "Samsung Mobile",
                Description = "RAM 6GB, Memory 128GB",
                Price = 20000,
                CategoryId = Guid.Parse("a7f3c821-4b92-4d16-9e35-72c8f1a604b9"),
                Quantity = 10,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product
            {
                Id = Guid.Parse("e8315a47-2c69-4f03-b728-91d6c5a84013"),
                Name = "Lenovo Laptop",
                Description = "RAM 16GB, Memory 1TB",
                Price = 10000,
                CategoryId = Guid.Parse("d2916e47-83ac-4f52-b719-05e4c9a2f638"),
                Quantity = 30,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product
            {
                Id = Guid.Parse("5d29f816-73b4-4c62-ae05-38f1b927640c"),
                Name = "X-200 Sport Watch",
                Description = "AMOLED, GPS",
                Price = 30000,
                CategoryId = Guid.Parse("6c48b2f9-e157-43a6-8d21-f90b735c4a82"),
                Quantity = 20,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            });
    }

    #endregion

    #region Categories

    private static void SeedCategories(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = Guid.Parse("a7f3c821-4b92-4d16-9e35-72c8f1a604b9"),
                Name = "Mobile",
                Description = "For calling and playing"
            },
            new Category
            {
                Id = Guid.Parse("d2916e47-83ac-4f52-b719-05e4c9a2f638"),
                Name = "Laptop",
                Description = "For programming, studying and gaming"
            },
            new Category
            {
                Id = Guid.Parse("6c48b2f9-e157-43a6-8d21-f90b735c4a82"),
                Name = "Accessory",
                Description = "For example, watch and sock"
            }
        );
    }

    #endregion

    #region Users

    private static void SeedUsers(ModelBuilder modelBuilder)
    {
        var user = new User()
        {
            Id = Guid.Parse("f2a81c47-93d5-4e62-b718-6c04a9d35127"),
            IsActive = true,
            Name = "a",
            RoleId = RoleIds.Admin,
        };

        user.PasswordHash = "AQAAAAIAAYagAAAAEGXenaaSLxper4UJoQ+gez+Olv2R2siuXVFVzUk4rVVfRukD/vbVe17dsaU8PNLtgw==";

        modelBuilder.Entity<User>().HasData(user);

    }

    #endregion
}
