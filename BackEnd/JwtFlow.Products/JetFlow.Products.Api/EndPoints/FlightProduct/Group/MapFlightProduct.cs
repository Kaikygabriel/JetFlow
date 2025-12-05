
using JetFlow.Products.Api.EndPoints.FlightProduct.EndPoint.AddUser;
using JetFlow.Products.Api.EndPoints.FlightProduct.EndPoint.Create;
using JetFlow.Products.Api.EndPoints.FlightProduct.EndPoint.GetAll;
using JetFlow.Products.Api.EndPoints.FlightProduct.EndPoint.GetByUser;

namespace JetFlow.Products.Api.EndPoints.FlightProduct.Group;

public static class MapFlightProduct
{
    public static void MapFlight(this WebApplication app)
    {
        var group = app.MapGroup("Flight");
        MapGetAll.Map(group);
        MapPost.Map(group);
        MapGetByUser.Map(group);
        MapPostAddUser.Map(group);
    }
}