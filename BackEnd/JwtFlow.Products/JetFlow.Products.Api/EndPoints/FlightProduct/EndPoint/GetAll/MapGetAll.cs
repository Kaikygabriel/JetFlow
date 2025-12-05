using JwtFlow.Application.UseCases.Flight.Query.GetAll;
using MediatorX.Core.Abstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JetFlow.Products.Api.EndPoints.FlightProduct.EndPoint.GetAll;

public class MapGetAll : IEndPoint
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapGet("/", async ([FromServices] IMediator mediator,
            [FromQuery] int skip, [FromQuery] int take) =>
        {
            var query = new GetAllQuery(skip, take);
            var result = await mediator.SendAsync(query);
            return result is not null ? Results.Ok(result) : Results.BadRequest();
        });
    }
}