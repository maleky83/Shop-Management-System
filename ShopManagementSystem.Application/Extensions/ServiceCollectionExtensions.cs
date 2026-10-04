using Microsoft.Extensions.DependencyInjection;
using ShopManagementSystem.Application.Interfaces.Authentication;
using ShopManagementSystem.Application.Interfaces.Catalog;
using ShopManagementSystem.Application.Interfaces.Shopping;
using ShopManagementSystem.Application.Interfaces.Users;
using ShopManagementSystem.Application.Services.Authentication;
using ShopManagementSystem.Application.Services.Catalog;
using ShopManagementSystem.Application.Services.Shopping;
using ShopManagementSystem.Application.Services.Users;

namespace ShopManagementSystem.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddAutoMapper(cfg => { }, applicationAssembly);

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICartService, CartService>();
    }
}
