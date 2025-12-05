using JwtFlow.Application.UseCases.Flight.Command.Create;
using MediatorX.Core.Abstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JetFlow.Products.Api.EndPoints.FlightProduct.EndPoint.Create;

public class MapPost : IEndPoint
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapPost("/", async ([FromServices]IMediator mediator ,
            [FromBody]CreateCommand createCommand) =>
        {
            var results = await mediator.SendAsync(createCommand);
            return results ?Results.Created() : Results.BadRequest();
        });
    }
}