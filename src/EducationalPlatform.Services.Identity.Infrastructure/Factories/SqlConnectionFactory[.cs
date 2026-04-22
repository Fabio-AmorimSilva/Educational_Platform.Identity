namespace EducationalPlatform.Services.Identity.Infrastructure.Factories;

public class SqlConnectionFactory(IConfiguration configuration) : IDbConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        var connectionString = configuration.GetSection("DefaultConnection").Value ?? throw new InvalidOperationException();

        return new SqlConnection(connectionString);
    }
}