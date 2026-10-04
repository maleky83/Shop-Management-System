using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopManagementSystem.Infrastructure.Persistence;

namespace ShopManagementSystem.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastrucure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ApplicationDb");
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

    }
}
