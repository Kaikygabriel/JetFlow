using JwtFlow.Domain.BackOffice.Interface;
using MediatorX.Core.Abstraction.Interfaces;

namespace JwtFlow.Application.UseCases.Flight.Command.Update;

public class UpdateHandler : HandlerBase,IHandler<UpdateCommand,bool>
{
    public UpdateHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> HandleAsync(UpdateCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            return await UpdateFlight(request);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private async Task<bool> UpdateFlight(UpdateCommand request)
    {
        if (_unitOfWork.RepositoryProductFlight.GetByPredicate(x => x.Id == request.Id) is null)
            return false;
        
        _unitOfWork.RepositoryProductFlight.Update(request.Model);
        await _unitOfWork.CommitAsync();
        return true;
    }
}