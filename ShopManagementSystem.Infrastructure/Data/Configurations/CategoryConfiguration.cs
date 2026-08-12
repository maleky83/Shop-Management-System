using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagementSystem.Domain.Entities.Category;

namespace ShopManagementSystem.Infrastructure.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasData(new Category
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
    }
}
