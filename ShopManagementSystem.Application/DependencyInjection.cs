using Microsoft.Extensions.DependencyInjection;
using ShopManagementSystem.Application.Interfaces.Authentication;
using ShopManagementSystem.Application.Interfaces.Catalog;
using ShopManagementSystem.Application.Interfaces.Common;
using ShopManagementSystem.Application.Interfaces.Shopping;
using ShopManagementSystem.Application.Interfaces.Users;
using ShopManagementSystem.Application.Mappings;
using ShopManagementSystem.Application.Services.Authentication;
using ShopManagementSystem.Application.Services.Catalog;
using ShopManagementSystem.Application.Services.Common;
using ShopManagementSystem.Application.Services.Shopping;
using ShopManagementSystem.Application.Services.Users;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<ICartService, CartService>();

        services.AddAutoMapper(config =>
        {
            config.AddProfile<ProductProfile>();
            config.AddProfile<CategoryProfile>();
            config.AddProfile<UsertProfile>();
            config.AddProfile<RoleProfile>();
            config.AddProfile<CartProfile>();
        });

        return services;
    }
}