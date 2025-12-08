using JetFlow.Domain.BackOffice.Interfaces;
using JetFlow.Infra.Repositories;
using JetFlow.Infra.Services;
using JetFlow.Infra.Services.Contracts;
using JetFlow.Infra.UseCases;
using JetFlow.Infra.UseCases.User.Command.Create;

namespace JetFlow.Auth.Api.Extensions;

public static class Ioc
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddMediatR(x=>
            x.RegisterServicesFromAssembly(typeof(HandlerBase).Assembly));
        services.AddScoped<IServiceToken,ServiceToken>();
        services.AddScoped<IRepositoryUser,RepositoryUser>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}