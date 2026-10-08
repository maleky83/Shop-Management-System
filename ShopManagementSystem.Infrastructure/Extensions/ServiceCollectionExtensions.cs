using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopManagementSystem.Domain.Repositories;
using ShopManagementSystem.Domain.Repositories.Shopping;
using ShopManagementSystem.Infrastructure.Persistence;
using ShopManagementSystem.Infrastructure.Repositories;
using ShopManagementSystem.Infrastructure.Repositories.Shopping;

namespace ShopManagementSystem.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastrucure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ApplicationDb");
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
