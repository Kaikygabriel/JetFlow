using JetFlow.Cart.Application.UseCases.Cart.Query.GetCartByUserId;
using MediatorX.Core.Abstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JetFlow.Cart.Api.EndPoints.Cart.EndPoint;
 
public class MapGetByIdUser : IEndPoint
{
    public static void Map(IEndpointRouteBuilder group)
        => group.MapGet("/GetByIdUser", async ([FromQuery]int userId,IMediator mediator) =>
        {
            var query = new GetCartByUserIdQuery(userId);
            var result = await mediator.SendAsync(query);
            return result is not null
                ? Results.Ok(new {Cart=result,Items = result.GetCartItems() })
                : Results.NotFound("Cart not found");
        });
}