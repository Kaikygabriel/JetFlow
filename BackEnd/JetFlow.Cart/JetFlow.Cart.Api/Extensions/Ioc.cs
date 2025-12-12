using JetFlow.Cart.Application.UseCases;
using JetFlow.Cart.Domain.BackOffice.Interfaces;
using JetFlow.Cart.Domain.BackOffice.Interfaces.Cart;
using JetFlow.Cart.Domain.BackOffice.Interfaces.CartItem;
using JetFlow.Cart.Infra.Data;
using JetFlow.Cart.Infra.Data.Contracts;
using JetFlow.Cart.Infra.Repositories;
using JetFlow.Cart.Infra.Repositories.Cart;
using MediatorX.Core.DependencyInjection;

namespace JetFlow.Cart.Api.Extensions;

public static class Ioc
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddMediator(typeof(HandlerBase).Assembly);
        services.AddScoped<IConnectionSql,ConnectionSql>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRepositoryCart, RepositoryCart>();
        
        return services;
    }
}