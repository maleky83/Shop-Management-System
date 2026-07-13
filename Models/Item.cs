using System.Collections;
using System.Collections.Generic;

namespace program.Models
{
    public class Item
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }

        // Navigation Property
        public Product Product { get; set; }
    }
}
