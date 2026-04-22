namespace EducationalPlatform.Services.Identity.Application.Responses;

public class NoContentResponse<T> : ApiResponse<T>
{
    public NoContentResponse()
    {
        StatusCode = 204;
        IsSuccess = true;
    }
}