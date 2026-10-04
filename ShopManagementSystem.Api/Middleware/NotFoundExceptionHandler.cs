using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.Exceptions;

namespace ShopManagementSystem.Api.Middleware;

public class NotFoundExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not NotFoundException)
        {
            return false;
        }

        var context = new ProblemDetailsContext
        {
            Exception = exception,
            HttpContext = httpContext,
            ProblemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Detail = "asdf",
            }
        };

        return await problemDetailsService.TryWriteAsync(context);
    }
}
