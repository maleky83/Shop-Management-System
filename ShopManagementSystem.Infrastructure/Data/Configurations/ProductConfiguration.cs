using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagementSystem.Domain.Entities;

namespace ShopManagementSystem.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product()
            {
                Id = 1,
                Name = "Sumsung Mobile",
                Description = "ram 6 , memory 128",
                PictureName = "1.jpg",
            },
                new Product()
                {
                    Id = 2,
                    Name = "lenovo laptop",
                    Description = "ram 16 , memory 1T",
                    PictureName = "2.jpg",
                },
                new Product()
                {
                    Id = 3,
                    Name = "X-200 sport Watch",
                    Description = " AMOLED،GPS ",
                    PictureName = "3.jpg",
                });

        }
    }
}
