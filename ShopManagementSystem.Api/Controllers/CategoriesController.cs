using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Category;
using ShopManagementSystem.Application.Interfaces.Catalog;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("Categories")]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<CategoriesCollectionDto> GetCategories()
    {
        var categoriesCollectionDto = new CategoriesCollectionDto
        {
            Data = await categoryService.GetAllAsync()
        };

        return categoriesCollectionDto;
    }
}
