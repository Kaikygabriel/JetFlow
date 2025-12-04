namespace JetFlow.Products.Api.EndPoints.FlightProduct.EndPoint;

public class MapGetAll : IEndPoint
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapGet("/", () =>
        {
            return Results.Ok("DEU CERTO");
        });
    }
}