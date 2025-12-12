using JetFlow.Cart.Application.UseCases.Cart.Command.Create;
using MediatorX.Core.Abstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JetFlow.Cart.Api.EndPoints.Cart.EndPoint;

public  class MapPost : IEndPoint
{
    public static void Map(IEndpointRouteBuilder group)
        => group.MapPost("/", async ([FromServices] IMediator mediator,[FromBody] CreateCartCommand command) =>
        {
            var result = await mediator.SendAsync(command,default);
            return result ? Results.Created() : Results.BadRequest("deu errado");
        });
}