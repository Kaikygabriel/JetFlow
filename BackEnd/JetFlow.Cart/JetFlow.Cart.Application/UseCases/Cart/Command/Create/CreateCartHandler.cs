using JetFlow.Cart.Domain.BackOffice.Interfaces;
using MediatorX.Core.Abstraction.Interfaces;

namespace JetFlow.Cart.Application.UseCases.Cart.Command.Create;

public class CreateCartHandler  : HandlerBase, 
    IHandler<CreateCartCommand,bool>
{
    public CreateCartHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> HandleAsync
        (CreateCartCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            return await CreateCart(request);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private async Task<bool> CreateCart(CreateCartCommand request)
    {
        if (request.Cart is null)
            return false;
        
        var cartExisting = await UnitOfWork.RepositoryCart.GetByPredicate(x => x.UserId == request.Cart.UserId);
        if (cartExisting is not null)
            return false;
        
        UnitOfWork.RepositoryCart.Create(request.Cart);
        await UnitOfWork.CommitAsync();
        
        return true;
    }
}