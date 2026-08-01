using Program.Data.Entities;
using Program.Data.Entities.Category;

namespace Program.Core.DTOs
{
    public class DetailsViewModel
    {
        public Product product { get; set; }
        public List<Category> categories { get; set; }
    }
}
