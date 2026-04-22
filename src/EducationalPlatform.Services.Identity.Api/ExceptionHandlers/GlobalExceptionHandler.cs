namespace EducationalPlatform.Services.Identity.Api.ExceptionHandlers;

public class GlobalExceptionHandler(
    IProblemDetailsService problemDetailsService,
    ILogger<GlobalExceptionHandler> logger
) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        logger.LogError(exception, exception.Message);

        httpContext.Response.StatusCode = exception switch
        {
            ApplicationException => 400,
            _ => StatusCodes.Status500InternalServerError
        };

        return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = new ProblemDetails
            {
                Type = exception.GetType().FullName,
                Title = "An error occurred",
                Detail = exception.Message,
                Status = httpContext.Response.StatusCode
            }
        });
    }
}