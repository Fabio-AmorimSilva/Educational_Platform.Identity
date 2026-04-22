namespace EducationalPlatform.Services.Identity.Api.Controllers;

[ApiController]
public class BaseController(UseCaseValidation validation) : ControllerBase
{
    public async Task<IActionResult> Execute<TUseCase, TRequest, TResponse>(TRequest request) where TUseCase : class
    {
        var result = await validation.Execute<TUseCase, TRequest, TResponse>(request);

        return MapResponse((dynamic)result!);
    }

    private IActionResult MapResponse<T>(UseCaseResult<T>? result)
        => result switch
        {
            OkResponse<T> ok => Ok(ok.Data),

            CreatedResponse<T> created => Created(
                string.Empty,
                created.Data),

            NotFoundResponse<T> notFound => NotFound(
                new ProblemDetails
                {
                    Title = "Resource not found",
                    Detail = notFound.Message,
                    Status = 404
                }),

            UnprocessableResponse<T> unprocessable => UnprocessableEntity(
                new ProblemDetails
                {
                    Title = "Validation error",
                    Detail = unprocessable.Message,
                    Status = 422
                }),

            NoContentResponse<T> => NoContent(),

            _ => Problem(
                title: "Unexpected error",
                statusCode: 500)
        };
}