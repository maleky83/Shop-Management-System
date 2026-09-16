using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Application.Interfaces.Catalog;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("products")]
public sealed class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ProductsCollectionDto>> GetProducts()
    {
        List<ProductDto> products = await productService.GetAllAsync();

        return Ok(new ProductsCollectionDto
        {
            Data = products
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(string id)
    {
        ProductDto product = await productService.GetByIdAsync(id);

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductDto model)
    {
        ProductDto product = await productService.CreateAsync(model);

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = product.ProductId },
            product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        string id,
        [FromBody] UpdateProductDto model)
    {
        await productService.UpdateAsync(id, model);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await productService.DeleteByIdAsync(id);

        return NoContent();
    }
}
