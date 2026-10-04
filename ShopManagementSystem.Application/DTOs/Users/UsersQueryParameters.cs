using Microsoft.AspNetCore.Mvc;

namespace ShopManagementSystem.Application.DTOs.Users;

public sealed record UsersQueryParameters
{
    [FromQuery(Name = "s")]
    public string? Search { get; set; }
}
