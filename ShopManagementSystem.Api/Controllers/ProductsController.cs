using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.ProductViewModels;
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
        public async Task<ActionResult<List<ProductViewModel>>> GetProducts()
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

            return NoContent();
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(int id, ProductViewModel model)
        //{
        //    await _productService.UpdateAsync(model);
        //    return NoContent();
        //}
    }
}
