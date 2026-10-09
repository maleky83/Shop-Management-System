using Microsoft.AspNetCore.Diagnostics;
using ShopManagementSystem.Application.Exceptions;

public class NotFoundExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not NotFoundException)
            return false;

        httpContext.Response.StatusCode = 404;

        await httpContext.Response.WriteAsync(
            "Resource not found",
            cancellationToken);

        return true;
    }
}
