using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.DTOs.Users;
using ShopManagementSystem.Application.Interfaces.Users;
using ShopManagementSystem.Application.Users.Dtos;

namespace ShopManagementSystem.Api.Controllers;

[ApiController]
[Route("users")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<UsersCollectionDto>> GetUsers()
    {
        UsersCollectionDto users = await userService.GetAllAsync();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser([FromRoute] Guid id)
    {
        UserDto user = await userService.GetByIdAsync(id);

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserDto model)
    {
        UserDto user = await userService.CreateAsync(model);

        return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(
        [FromRoute] Guid id,
        [FromBody] UpdateUserDto model)
    {
        await userService.UpdateAsync(id, model);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] Guid id)
    {
        await userService.DeleteAsync(id);

        return NoContent();
    }
}
