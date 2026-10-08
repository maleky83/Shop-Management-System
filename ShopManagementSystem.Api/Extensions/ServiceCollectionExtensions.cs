using ShopManagementSystem.Api.Middleware;

namespace ShopManagementSystem.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApi(this IServiceCollection services)
    {
        services.AddExceptionHandler<NotFoundExceptionHandler>();
        services.AddExceptionHandler<ValidationExceptionHandler>();
        services.AddExceptionHandler<GlobalExceptionHandler>();
    }
}
