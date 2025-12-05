using JwtFlow.Application.UseCases;
using JwtFlow.Domain.BackOffice.Interface;
using JwtFlow.Domain.BackOffice.Interface.ProductFlight;
using JwtFlow.Infra.Repositories;
using JwtFlow.Infra.Repositories.Flight;
using MediatorX.Core.DependencyInjection;

namespace JetFlow.Products.Api.Extensions;

public static class Ioc
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddMediator(typeof(HandlerBase).Assembly);
        services.AddScoped<IRepositoryProductFlight, FlightsRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}