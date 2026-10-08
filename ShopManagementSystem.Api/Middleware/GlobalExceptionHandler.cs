using Microsoft.AspNetCore.Diagnostics;

namespace ShopManagementSystem.Api.Middleware;

public sealed class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Unhandled exception occurred");

        context.Response.StatusCode =
            StatusCodes.Status500InternalServerError;

        await context.Response.WriteAsJsonAsync(
            new
            {
                title = "Internal Server Error",
                detail = "An error occurred while processing your request.",
                status = 500
            },
            cancellationToken);

        return true;
    }
}