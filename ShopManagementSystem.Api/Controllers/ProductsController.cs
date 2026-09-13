using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Application.Interfaces.Catalog;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("products")]
public sealed class ProductsController(IProductService _productService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetProducts()
    {
        List<ProductDto> products = await _productService.GetAllAsync();

        var productsCollectionDto = new ProductsCollectionDto
        {
            Data = products
        };
        return Ok(productsCollectionDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        ProductDto products = await _productService.GetByIdAsync(id);

        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateProductDto model)
    {
        await _productService.CreateAsync(model);

        return Ok(new
        {
            message = "Product Added"
        });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateProductDto model)
    {
        await _productService.UpdateAsync(id, model);

        return Ok(new
        {
            message = "Product updated"
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
}
