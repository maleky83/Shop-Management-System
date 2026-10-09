using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

public class ValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
            return false;

        httpContext.Response.StatusCode = 400;

        var errors = validationException.Errors
            .Select(e => e.ErrorMessage)
            .ToArray();

        await httpContext.Response.WriteAsJsonAsync(
            new
            {
                Message = "Validation failed",
                Errors = errors
            },
            cancellationToken);

        return true;
    }
}
