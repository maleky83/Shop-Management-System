using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagementSystem.Domain.Entities;

namespace ShopManagementSystem.Infrastructure.Data.Configurations
{
    public class CategoryToProductConfiguration : IEntityTypeConfiguration<CategoryToProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryToProduct> builder)
        {
            builder.HasKey(p => new { p.ProductId, p.CategoryId });
        }
    }
}
