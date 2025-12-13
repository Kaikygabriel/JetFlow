namespace JetFlow.Web.Extensions;

public static class BaseUrls
{
    public static IServiceCollection AddHttpClientsServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddHttpClient("ProductClient",x 
            => x.BaseAddress = new Uri(configuration["Url:Product"]!));
        
        services.AddHttpClient("AuthClient",x 
            => x.BaseAddress = new Uri(configuration["Url:Auth"]!));
        
        return services;
    }
}