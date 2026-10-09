using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.Categories.Dtos;
using ShopManagementSystem.Application.Categories.Queries.GetAllCategories;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("Categories")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
    {
        IEnumerable<CategoryDto> categories = await mediator.Send(new GetAllCategoriesQuery());

        return Ok(categories);
    }
}
