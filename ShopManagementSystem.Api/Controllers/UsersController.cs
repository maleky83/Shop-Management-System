using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Users;
using ShopManagementSystem.Application.Interfaces.Users;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<UserViewModel>>> GetAll()
    {
        List<UserViewModel> users = await userService.GetAllAsync();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserViewModel model)
    {
        await userService.CreateAsync(model);

        return Ok(new
        {
            message = "User == created"
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserViewModel>> GetById(int id)
    {
        UserViewModel user = await userService.GetByIdAsync(id);

        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserViewModel model)
    {
        await userService.UpdateAsync(id, model);

        return Ok(new
        {
            message = "User == updated"
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await userService.DeleteAsync(id);

        return Ok(new
        {
            message = "User == Deleted"
        });
    }
}
