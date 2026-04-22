namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure()
        {
            
            return services;
        }

        public IServiceCollection AddConnectionFactory()
        {
            services.AddScoped<IDbConnectionFactory, SqlConnectionFactory>();
            
            return services;
        }
    }
}