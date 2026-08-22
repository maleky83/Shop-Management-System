using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Application.Interfaces.Services;

namespace ShopManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/products/")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductViewModel>>> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetById(int id)
        {
            var products = await _productService.GetByIdAsync(id);

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductViewModel model)
        {
            await _productService.CreateAsync(model);

            return Ok(new
            {
                message = "Product Added"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteByIdAsync(id);

            return Ok(new
            {
                message = "Product deleted"
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProductViewModel model)
        {
            await _productService.UpdateAsync(id, model);
            return NoContent();
        }

    }
}
