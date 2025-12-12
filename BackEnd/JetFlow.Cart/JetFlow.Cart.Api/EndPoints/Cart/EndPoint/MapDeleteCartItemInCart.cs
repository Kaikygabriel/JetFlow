using JetFlow.Cart.Application.UseCases.Cart.Command.DeleteItem;
using MediatorX.Core.Abstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JetFlow.Cart.Api.EndPoints.Cart.EndPoint;

public class MapDeleteCartItemInCart : IEndPoint
{
    public static void Map(IEndpointRouteBuilder group)
        => group.MapDelete("/RemoveCartItem", async ([FromQuery]int idCart,[FromQuery] int idUser,
            IMediator mediator) =>
        {
            var command = new DeleteItemCommand(idCart,idUser);
            var result = await mediator.SendAsync(command);
            return result ? Results.Ok():Results.BadRequest() ;
        });
}
//fazer uma verficação de que o item a ser deletado esta no carrinho do USUARIO