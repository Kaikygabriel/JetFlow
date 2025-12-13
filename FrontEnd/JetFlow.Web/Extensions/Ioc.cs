using JetFlow.Web.Auth.Interfaces;
using JetFlow.Web.Auth.Service;
using JetFlow.Web.Product.Interfaces;
using JetFlow.Web.Product.Services;

namespace JetFlow.Web.Extensions;

public static class Ioc
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IServiceFlight, ServiceFlight>();
        services.AddScoped<IServiceAuth,ServiceAuth>();

        return services;
    }
}