
using JetFlow.Products.Api.EndPoints.FlightProduct.EndPoint.AddUser;
using JetFlow.Products.Api.EndPoints.FlightProduct.EndPoint.Create;
using JetFlow.Products.Api.EndPoints.FlightProduct.EndPoint.GetAll;
using JetFlow.Products.Api.EndPoints.FlightProduct.EndPoint.GetByUser;

namespace JetFlow.Products.Api.EndPoints.FlightProduct.Group;

public static class MapFlightProduct
{
    public static void MapFlight(this WebApplication app)
    {
        var group = app.MapGroup("Flight")
            .WithTags("Flight")
            .AddMap<MapGetAll>()
            .AddMap<MapPost>()
            .AddMap<MapGetByUser>()
            .AddMap<MapPostAddUser>();
    }

    public static RouteGroupBuilder AddMap<T>(this RouteGroupBuilder group) where T : IEndPoint
    {
        T.Map(group);
        return group;
    }
}