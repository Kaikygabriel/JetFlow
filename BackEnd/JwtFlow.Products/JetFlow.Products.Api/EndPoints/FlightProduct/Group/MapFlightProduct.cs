using JetFlow.Products.Api.EndPoints.FlightProduct.EndPoint;

namespace JetFlow.Products.Api.EndPoints.FlightProduct.Group;

public static class MapFlightProduct
{
    public static void MapFlight(this WebApplication app)
    {
        var group = app.MapGroup("teste");
        MapGetAll.Map(group); 
    }
}