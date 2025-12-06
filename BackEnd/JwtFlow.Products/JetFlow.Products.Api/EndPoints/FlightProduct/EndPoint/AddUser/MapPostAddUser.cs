
using JwtFlow.Application.UseCases.Flight.Command.AddUserInFlight;
using MediatorX.Core.Abstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JetFlow.Products.Api.EndPoints.FlightProduct.EndPoint.AddUser;

public class MapPostAddUser :  IEndPoint
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapPost("/AddUser", async
            ([FromServices] IMediator mediator, [FromBody]AddUserCommand command) =>
        {
            var result = await mediator.SendAsync(command);
            return result ? Results.NoContent() : Results.NotFound();
        });
    }
}