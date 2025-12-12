using MediatorX.Core.Abstraction.Interfaces;
using JetFlow.Cart.Application.UseCases.Cart.Command.AddITem;
using Microsoft.AspNetCore.Mvc;

namespace JetFlow.Cart.Api.EndPoints.Cart.EndPoint;

public class MapPostAddItem : IEndPoint
{
    public static void Map(IEndpointRouteBuilder group)
        => group.MapPost("/AddItem", async ([FromBody]AddItemCommand command,IMediator mediator ) =>
        {
            var result = await mediator.SendAsync(command);
            return result ? Results.Created() : Results.BadRequest();
        });
}