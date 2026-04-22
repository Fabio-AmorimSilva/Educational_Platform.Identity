namespace EducationalPlatform.Services.Identity.Application.Responses;

public class ApiResponse<T> : UseCaseResult<T>
{
    public int StatusCode { get; set; }
}