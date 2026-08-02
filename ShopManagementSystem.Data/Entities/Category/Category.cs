using System.Collections;
using System.Collections.Generic;

namespace ShopManagementSystem.Data.Entities.Category
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
    }
}
