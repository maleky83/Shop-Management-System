using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Users;
using ShopManagementSystem.Application.Interfaces.Users;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("users")]
public sealed class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetUsers()
    {
        List<UserDto> users = await userService.GetAllAsync();

        var usersCollectionDto = new UsersCollectionDto
        {
            Data = users
        };

        return Ok(usersCollectionDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto model)
    {
        await userService.CreateAsync(model);

        return Ok(new
        {
            message = "User == created"
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
        UserDto user = await userService.GetByIdAsync(id);

        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserDto model)
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
