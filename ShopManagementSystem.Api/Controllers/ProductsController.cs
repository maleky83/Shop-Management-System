using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.ProductViewModels;
using ShopManagementSystem.Application.Interfaces;

namespace ShopManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("products")]
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
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("group/{categoryId}")]
        public async Task<ActionResult<List<ProductViewModel>>> ShowProductByGroupId(int categoryId)
        {
            List<ProductViewModel> products = await _productService.ShowProductByGroupIdAsync(categoryId);
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductDetailsViewModel>> GetProduct(int productId)
        {
            var productDetail = await _productService.GetProductDetails(productId);

            if (productDetail == null)
                return NotFound();

            return Ok(productDetail);
        }
    }
}
