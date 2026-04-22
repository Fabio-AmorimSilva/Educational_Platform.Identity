namespace EducationalPlatform.Services.Identity.Infrastructure.Factories;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}