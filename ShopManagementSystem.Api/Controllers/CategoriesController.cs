using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.Categories.Dtos;
using ShopManagementSystem.Application.Interfaces.Catalog;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("Categories")]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CategoriesCollectionDto>> GetCategories()
    {
        CategoriesCollectionDto categories = await categoryService.GetAllAsync();

        return Ok(categories);
    }
}
