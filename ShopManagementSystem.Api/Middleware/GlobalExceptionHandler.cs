using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ShopManagementSystem.Api.Middleware;

public sealed class GlobalExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
        )
    {

        var contex = new ProblemDetailsContext
        {
            Exception = exception,
            HttpContext = httpContext,
            ProblemDetails = new ProblemDetails
            {
                Title = "Internal Server Error",
                Detail = "An error occurred while processing your request. Please try again",
                Status = StatusCodes.Status500InternalServerError,
            }
        };

        var error = exception.Message;

        contex.ProblemDetails.Extensions.Add("error", error);

        return problemDetailsService.TryWriteAsync(contex);
    }
}
