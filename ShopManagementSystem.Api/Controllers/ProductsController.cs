using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Application.Interfaces.Catalog;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("products")]
public sealed class ProductsController(
    IProductService productService
    ) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ProductsCollectionDto>> GetProducts()
    {
        ProductsCollectionDto products = await productService.GetAllAsync();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct([FromRoute] Guid id)
    {
        ProductDto product = await productService.GetByIdAsync(id);

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(
       [FromBody] CreateProductDto createProductDto,
       [FromServices] IValidator<CreateProductDto> validator)
    {
        await validator.ValidateAndThrowAsync(createProductDto);

        Guid productId = await productService.CreateAsync(createProductDto);

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = productId });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduct(
        [FromRoute] Guid id,
        [FromBody] UpdateProductDto updateProductDto)
    {
        await productService.UpdateAsync(id, updateProductDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct([FromRoute] Guid id)
    {
        await productService.DeleteAsync(id);

        return NoContent();
    }
}
