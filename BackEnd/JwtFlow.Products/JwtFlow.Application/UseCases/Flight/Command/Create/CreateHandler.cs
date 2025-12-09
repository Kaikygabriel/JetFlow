using JwtFlow.Domain.BackOffice.Interface;
using MediatorX.Core.Abstraction.Interfaces;

namespace JwtFlow.Application.UseCases.Flight.Command.Create;

public class CreateHandler  : HandlerBase,IHandler<CreateCommand,bool>
{
    public CreateHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> HandleAsync(CreateCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            return await CreateProductFlightOrException(request);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private async Task<bool> CreateProductFlightOrException(CreateCommand request)
    {
        var productExisting = await _unitOfWork.RepositoryProductFlight.
            GetByPredicate(x => x.Name == request.Product.Name);
        if (productExisting is not null)
            return false;
        _unitOfWork.RepositoryProductFlight.Create(request.Product);
        await _unitOfWork.CommitAsync();
        return true;
    }
}