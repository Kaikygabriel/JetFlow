using JetFlow.Cart.Domain.BackOffice.Interfaces;
using MediatorX.Core.Abstraction.Interfaces;

namespace JetFlow.Cart.Application.UseCases.Cart.Query.GetCartByUserId;

public class GetCartByIdUserHandler : HandlerBase,
    IHandler<GetCartByUserIdQuery,Domain.BackOffice.Entities.Cart?>
{
    public GetCartByIdUserHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<Domain.BackOffice.Entities.Cart?> HandleAsync
        (GetCartByUserIdQuery request, CancellationToken cancellationToken = new CancellationToken())
    {
        var cart = await UnitOfWork.RepositoryCart.GetByUserId(request.UserId);
        if (cart is null) return null;
        
        foreach (var item in await UnitOfWork.RepositoryCartItem.GetAllByUserId(cart.UserId))
            cart.AddCartInItems(item);
        
        return cart;
    }
}