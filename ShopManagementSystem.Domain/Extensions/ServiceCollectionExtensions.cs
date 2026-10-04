using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDomain(this IServiceCollection services)
    {

        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
    }
}
