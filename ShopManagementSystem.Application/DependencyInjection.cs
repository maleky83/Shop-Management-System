using Microsoft.Extensions.DependencyInjection;
using ShopManagementSystem.Application.Interfaces.Services;
using ShopManagementSystem.Application.Mappings;
using ShopManagementSystem.Application.Services;

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

        services.AddAutoMapper(config =>
        {
            config.AddProfile<ProductProfile>();
            config.AddProfile<CategoryProfile>();
            config.AddProfile<UsertProfile>();
            config.AddProfile<RoleProfile>();
        });

        return services;
    }
}