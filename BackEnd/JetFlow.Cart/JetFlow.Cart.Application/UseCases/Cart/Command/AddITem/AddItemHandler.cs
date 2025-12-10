using JetFlow.Cart.Domain.BackOffice.Interfaces;
using MediatorX.Core.Abstraction.Interfaces;

namespace JetFlow.Cart.Application.UseCases.Cart.Command.AddITem;

public class AddItemHandler : HandlerBase, IHandler<AddItemCommand,bool>
{
    public AddItemHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> HandleAsync(AddItemCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            return await AddItem(request);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private async Task<bool> AddItem(AddItemCommand request)
    {
        var cart = await UnitOfWork.RepositoryCart.GetByPredicate(x => x.UserId == request.UserId);
        if (cart is null) return false;

        cart.AddCartInItems(request.Item);
        UnitOfWork.RepositoryCartItem.Create(request.Item);
        UnitOfWork.RepositoryCart.Update(cart);
        await UnitOfWork.CommitAsync();
        return true;
    }
}