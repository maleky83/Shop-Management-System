using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ShopManagementSystem.Application.Carts;
using ShopManagementSystem.Application.Categories;
using ShopManagementSystem.Application.Interfaces.Authentication;
using ShopManagementSystem.Application.Interfaces.Catalog;
using ShopManagementSystem.Application.Interfaces.Shopping;
using ShopManagementSystem.Application.Interfaces.Users;
using ShopManagementSystem.Application.Users;

namespace ShopManagementSystem.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        Assembly applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddAutoMapper(cfg => { }, applicationAssembly);

        services.AddValidatorsFromAssembly(applicationAssembly);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICartService, CartService>();

    }
}
