using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagementSystem.Domain.Entities.Products;

namespace ShopManagementSystem.Infrastructure.Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Price).HasColumnType("Money");
            builder.HasData(
            new Item { Id = 1, Price = 1250000, QuantityInStock = 45 },
            new Item { Id = 2, Price = 980000, QuantityInStock = 32 },
            new Item { Id = 3, Price = 4500000, QuantityInStock = 18 }
            );
        }
    }
}
