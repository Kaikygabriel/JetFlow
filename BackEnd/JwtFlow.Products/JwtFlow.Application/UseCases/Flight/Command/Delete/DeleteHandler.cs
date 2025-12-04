using JwtFlow.Domain.BackOffice.Interface;
using MediatorX.Core.Abstraction.Interfaces;

namespace JwtFlow.Application.UseCases.Flight.Command.Delete;

public class DeleteHandler : HandlerBase,IHandler<DeleteCommand,bool>
{
    public DeleteHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> HandleAsync(DeleteCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            var productFlight = await _unitOfWork.RepositoryProductFlight
                .GetByPredicate(x => x.Id.ToString() == request.IdFlight);
            if (productFlight is null) 
                return false;
            _unitOfWork.RepositoryProductFlight.Delete(productFlight);
            await _unitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}