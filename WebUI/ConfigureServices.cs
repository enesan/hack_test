using Newtonsoft.Json;

namespace Ancient;


public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddOpenApiDocument(configure =>
        {
            configure.Title = "Ancient test system";
        });
        
        return services;
    }
}