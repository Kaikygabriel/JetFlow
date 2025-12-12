using JetFlow.Cart.Domain.BackOffice.Interfaces;
using MediatorX.Core.Abstraction.Interfaces;

namespace JetFlow.Cart.Application.UseCases.Cart.Command.DeleteItem;

public class DeleteItemHandler : HandlerBase, 
    IHandler<DeleteItemCommand,bool>
{
    public DeleteItemHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> HandleAsync(DeleteItemCommand request, CancellationToken cancellationToken =default)
    { 
        return await DeleteItem(request);
    }

    private async Task<bool> DeleteItem(DeleteItemCommand request)
    {
        var item = await UnitOfWork.RepositoryCartItem.GetById(request.idCartItem);
        if (item is null) return false;
        if (item.UserId != request.userId) return false;

        await UnitOfWork.RepositoryCartItem.Delete(item);
        return true;
    }
}