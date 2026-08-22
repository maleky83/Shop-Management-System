using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Infrastructure.Data.Seed
{
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
                    Id = 1,
                    Name = "Sumsung Mobile",
                    Description = "ram 6 , memory 128",
                    PictureName = "1.jpg",
                    Price = 20000,
                    CategoryId = 1,
                    Quantity = 10,
                    CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                },
                new Product()
                {
                    Id = 2,
                    Name = "lenovo laptop",
                    Description = "ram 16 , memory 1T",
                    PictureName = "2.jpg",
                    Price = 10000,
                    CategoryId = 2,
                    Quantity = 30,
                    CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                },
                new Product()
                {
                    Id = 3,
                    Name = "X-200 sport Watch",
                    Description = " AMOLED،GPS ",
                    PictureName = "3.jpg",
                    Price = 30000,
                    CategoryId = 3,
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
        }

        #endregion

        #region Users

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                IsActive = true,
                Name = "a",
                PasswordHash = "AQAAAAIAAYagAAAAEJFJMLK8RQXhwNCo0C7ahb+wKtLiYnUUiEiKXwbKENtwFN/pYWMLY++k6vhRGmZ9gw==",
                RoleId = RoleIds.Admin,
            });
        }

        #endregion
    }
}
