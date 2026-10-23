using Microsoft.AspNetCore.Diagnostics;

namespace BenefitsWorkflow.Api.ExceptionHandling;

public sealed class ApiExceptionHandler(ILogger<ApiExceptionHandler> logger) : IExceptionHandler   
{

    // PRIMARY CONSTRUCTOR equivalent to below code 

    // private readonly ILogger<ApiExceptionHandler> _logger;
    // public ApiExceptionHandler(ILogger<ApiExceptionHandler> logger)
    // {
    //     _logger = logger;
    // }
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var (status, title, detail) = exception switch
        {
            KeyNotFoundException => (
                StatusCodes.Status404NotFound,
                "Resource not found",
                "The requested resource could not be found."),
            ArgumentException => (
                StatusCodes.Status400BadRequest,
                "Invalid request",
                "The request contains invalid data."),
            InvalidOperationException => (
                StatusCodes.Status409Conflict,
                "Request conflict",
                "The operation conflicts with the resource's current state."),
            _ => (
                StatusCodes.Status500InternalServerError,
                "Internal server error",
                "An unexpected error occurred.")
        };

        // logging helps developers to know what happened or where it happened in application code
        if (status == StatusCodes.Status500InternalServerError)
        {
            logger.LogError(
                exception,
                "Unhandled exception processing {Method} {Path}",
                httpContext.Request.Method,
                httpContext.Request.Path);
        }
        else
        {
            logger.LogWarning(
                exception,
                "Request failed with status {StatusCode} for {Method} {Path}",
                status,
                httpContext.Request.Method,
                httpContext.Request.Path);
        }

        await Results.Problem(
            statusCode: status,
            title: title,
            detail: detail,
            instance: httpContext.Request.Path,
            extensions: new Dictionary<string, object?>
            {
                ["traceId"] = httpContext.TraceIdentifier
            }).ExecuteAsync(httpContext);   // here ExecuteAsync is an await method , if it throws exception or if we intensionally 
            // returns false , ASP .NET core forwards the exception to  other global excetion handlers or fall backs 

        return true;
    }
}
