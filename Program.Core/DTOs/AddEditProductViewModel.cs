using Microsoft.AspNetCore.Http;
using Program.Data.Entities.Category;
namespace Program.Core.DTOs
{
    public class AddEditProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public int QuantityInStock { get; set; }
        public IFormFile Picture { get; set; }
        public List<Category> Categories { get; set; }
    }
}
