using JwtFlow.Application.UseCases.Flight.Query.GetByUser;
using MediatorX.Core.Abstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JetFlow.Products.Api.EndPoints.FlightProduct.EndPoint.GetByUser;

public class MapGetByUser : IEndPoint
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapGet("/GetByUser", async ([FromQuery] string userId
            , [FromServices] IMediator mediator) =>
        {
            var command = new GetByUserQuery(userId);
            var result = await mediator.SendAsync(command);
            return result is not null ? Results.Ok(result) : Results.BadRequest();
        });
    }
}