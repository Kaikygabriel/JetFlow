using JetFlow.Cart.Api.EndPoints.Cart.EndPoint;

namespace JetFlow.Cart.Api.EndPoints.Cart.Groups;

public static class CartGroup
{
    public static WebApplication MapCart(this WebApplication app)
    {
        var group = app.MapGroup("Cart")
            .WithTags("Cart")
            .AddMap<MapPost>()
            .AddMap<MapGetByIdUser>()
            .AddMap<MapPostAddItem>()
            .AddMap<MapDeleteCartItemInCart>();
        
        return app;
    }

    public static IEndpointRouteBuilder AddMap<T>(this IEndpointRouteBuilder group) 
        where T : IEndPoint
    {
        T.Map(group);
        return group;
    }
}