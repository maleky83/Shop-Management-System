using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Domain.Entities;
using ShopManagementSystem.Domain.Entities.User;

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

            SeedCategoryToProdcuts(modelBuilder);
            SeedPermissions(modelBuilder);
            SeedRolePermissions(modelBuilder);
            SeedUserRoles(modelBuilder);
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
                },
                new Product()
                {
                    Id = 2,
                    Name = "lenovo laptop",
                    Description = "ram 16 , memory 1T",
                    PictureName = "2.jpg",
                    Price = 10000,
                },
                new Product()
                {
                    Id = 3,
                    Name = "X-200 sport Watch",
                    Description = " AMOLED،GPS ",
                    PictureName = "3.jpg",
                    Price = 30000,
                });
        }

        #endregion

        #region CategoryToProducts

        private static void SeedCategoryToProdcuts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>().HasData(
                        new CategoryToProduct() { CategoryId = 1, ProductId = 1 },
                        new CategoryToProduct() { CategoryId = 2, ProductId = 2 },
                        new CategoryToProduct() { CategoryId = 3, ProductId = 3 }
                        );
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
            });
        }

        #endregion

        #region UserRoles

        private static void SeedUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                RoleId = RoleIds.Admin,
                UserId = 1,
            });
        }

        #endregion
    }
}
