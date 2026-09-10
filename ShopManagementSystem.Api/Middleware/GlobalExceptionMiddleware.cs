using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.Exceptions;

namespace ShopManagementSystem.Api.Middleware;

public class GlobalExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            BadRequestException => StatusCodes.Status400BadRequest,
            UnauthorizedException => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError,
        };

        context.Response.StatusCode = statusCode;

        var response = new ErrorResponse
        {
            StatusCode = statusCode,
            Message = exception.Message,
        };

        await context.Response.WriteAsJsonAsync(response, context.RequestAborted);
    }
}
